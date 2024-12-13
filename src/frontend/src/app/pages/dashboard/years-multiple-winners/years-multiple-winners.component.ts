import { Component, OnInit } from '@angular/core';
import { GetYearMultipleWinnersData } from '../../../models/get-years-multiple-winners-data';
import { BackendService } from '../../../services/backend.service';

@Component({
  selector: 'app-years-multiple-winners',
  standalone: false,

  templateUrl: './years-multiple-winners.component.html',
  styleUrl: './years-multiple-winners.component.css',
})
export class YearsMultipleWinnersComponent implements OnInit {
  yearsMultipleWinnersData?: GetYearMultipleWinnersData[];
  limit: number = 3;

  constructor(private backend: BackendService) {}

  ngOnInit(): void {
    this.getData();
  }

  async getData() {
    this.backend.getYearsMultipleWinners(this.limit).subscribe({
      next: (res) => {
        this.yearsMultipleWinnersData = res;
      },
    });
  }
}
