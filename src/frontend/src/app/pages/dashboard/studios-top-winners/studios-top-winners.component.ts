import { Component, OnInit } from '@angular/core';
import { BackendService } from '../../../services/backend.service';
import { GetStudiosTopWinnersData } from '../../../models/get-studios-top-winners-data';

@Component({
  selector: 'app-studios-top-winners',
  standalone: false,
  templateUrl: './studios-top-winners.component.html',
  styleUrl: './studios-top-winners.component.css',
})
export class StudiosTopWinnersComponent implements OnInit {
  studiosTopWinnersData?: GetStudiosTopWinnersData[];
  limit: number = 3;
  includeMovies: boolean = false;

  constructor(private backend: BackendService) {}

  ngOnInit(): void {
    this.getData();
  }

  async getData() {
    this.backend
      .getTopStudiosWithWinners(this.limit, this.includeMovies)
      .subscribe({
        next: (res) => {
          this.studiosTopWinnersData = res;
        },
      });
  }
}
