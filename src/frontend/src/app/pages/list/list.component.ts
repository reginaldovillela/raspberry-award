import { Component, OnInit } from '@angular/core';
import { BackendService } from '../../services/backend.service';
import { GetMoviesData } from '../../models/get-movies-data';

@Component({
  selector: 'app-list',
  standalone: false,

  templateUrl: './list.component.html',
  styleUrl: './list.component.css',
})
export class ListComponent implements OnInit {
  movieData?: GetMoviesData;
  listTypeofWinner: string[] = ['All', 'Yes', 'No'];
  listPageNumber: number[] = [];
  listPageSize: number[] = [10, 20, 30, 50, 100];
  currentFilterByYear: string = '';
  currentTypeofWinner: string = 'All';
  currentPageNumber: number = 1;
  currentPageSize: number = 20;

  constructor(private backend: BackendService) {}

  ngOnInit(): void {
    this.getData();
  }

  generatePageList(totalPages: number): void {
    this.listPageNumber = [];
    for (var i = 1; i <= totalPages; i++) {
      this.listPageNumber?.push(i);
    }
  }

  async getData() {

    this.backend
      .getMovies(
        this.currentPageNumber,
        this.currentPageSize,
        this.currentFilterByYear,
        this.currentTypeofWinner
      )
      .subscribe({
        next: (res) => {
          this.movieData = res;
          this.generatePageList(res.totalPages);
        },
      });
  }

  onChangePageNumber(pageNumber: number) {
    this.currentPageNumber = pageNumber;
    this.getData();
  }

  onChangePageSize(pageSize: number) {
    this.currentPageNumber = 1;
    this.currentPageSize = pageSize;
    this.getData();
  }

  onFilterByYear(year: string) {
    if (year.length == 0 || year.length == 4) {
      this.currentPageNumber = 1;
      this.getData();
    }
  }

  onChangeWinnersYesNo(typeofWinner: string) {
    this.currentTypeofWinner = typeofWinner;
    this.getData();
  }
}
