import { Component, OnInit } from '@angular/core';
import { GetMoviesData } from '../../../models/get-movies-data';
import { BackendService } from '../../../services/backend.service';

@Component({
  selector: 'app-list-movies-by-year',
  standalone: false,

  templateUrl: './list-movies-by-year.component.html',
  styleUrl: './list-movies-by-year.component.css',
})
export class ListMoviesByYearComponent implements OnInit {
  movieData?: GetMoviesData;
  listTypeofWinner: string[] = ['All', 'Yes', 'No'];
  listPageNumber: number[] = [];
  currentFilterByYear: string = '';
  currentTypeofWinner: string = 'Yes';
  currentPageNumber: number = 1;
  currentPageSize: number = 5;

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

  onFilterByYear(year: string) {
    console.log(year);
    if (year.length == 0 || year.length == 4) {
      this.currentPageNumber = 1;
      this.getData();
    }
  }
}
