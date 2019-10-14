import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  constructor(private httpClient: HttpClient) {}

  public get(): Observable<any> {
    return this.httpClient.get<any>(
      `https://localhost:5001/api/parkinglot/dashboard`
    );
  }
}
