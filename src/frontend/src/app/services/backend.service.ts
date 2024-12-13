import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/env.dev';
import { GetMoviesData } from '../models/get-movies-data';
import { GetStudiosTopWinnersData } from '../models/get-studios-top-winners-data';
import { GetYearMultipleWinnersData } from '../models/get-years-multiple-winners-data';
import { GetProducersMinMaxWinner } from '../models/get-producers-min-max-winner';

@Injectable({
  providedIn: 'root',
})
export class BackendService {
  private baseUrl: string = '';

  constructor(private http: HttpClient) {
    this.baseUrl = environment.backendAPI;
  }

  getMovies(
    pageNumber: number,
    pageSize: number,
    year: string,
    winners: string
  ): Observable<GetMoviesData> {
    let url = `${this.baseUrl}/movies?_pageNumber=${pageNumber}&_pageSize=${pageSize}`;

    if (year.length == 4) url += `&year=${year}`;

    switch (winners) {
      case 'Yes':
        url += `&winner=${true}`;
        break;
      case 'No':
        url += `&winner=${false}`;
        break;
    }

    return this.http.get<GetMoviesData>(url);
  }

  getYearsMultipleWinners(
    limit: number
  ): Observable<GetYearMultipleWinnersData[]> {
    let url = `${this.baseUrl}/movies/years-with-winners?limit=${limit}`;
    return this.http.get<GetYearMultipleWinnersData[]>(url);
  }

  getTopStudiosWithWinners(
    limit: number,
    includeMovies: boolean
  ): Observable<GetStudiosTopWinnersData[]> {
    let url = `${this.baseUrl}/studios/top-winners?limit=${limit}&includeMovies=${includeMovies}`;
    return this.http.get<GetStudiosTopWinnersData[]>(url);
  }

  getProducersMinMaxWinner(): Observable<GetProducersMinMaxWinner> {
    let url = `${this.baseUrl}/producers/min-max-winner`;
    return this.http.get<GetProducersMinMaxWinner>(url);
  }
}
