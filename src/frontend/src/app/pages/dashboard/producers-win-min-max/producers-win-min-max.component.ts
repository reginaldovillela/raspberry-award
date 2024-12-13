import { Component, OnInit } from '@angular/core';
import { GetProducersMinMaxWinner } from '../../../models/get-producers-min-max-winner';
import { BackendService } from '../../../services/backend.service';

@Component({
  selector: 'app-producers-win-min-max',
  standalone: false,

  templateUrl: './producers-win-min-max.component.html',
  styleUrl: './producers-win-min-max.component.css',
})
export class ProducersWinMinMaxComponent implements OnInit {
  producersMinMaxWinner?: GetProducersMinMaxWinner;

  constructor(private backend: BackendService) {}

  ngOnInit(): void {
    this.getData();
  }

  async getData() {
    this.backend.getProducersMinMaxWinner().subscribe({
      next: (res) => {
        this.producersMinMaxWinner = res;
      },
    });
  }
}
