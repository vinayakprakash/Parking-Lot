import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { VehicleLog } from '../models/vehiclelog.model';

@Injectable({
  providedIn: 'root'
})
export class VehicleLogService {
  apiUrl: string = 'https://localhost:5001/api/parkinglot/';

  constructor(private http: HttpClient) {}

  get() {
    return this.http.get<VehicleLog[]>(this.apiUrl + 'vehiclelog');
  }

  add(vehiclelog: VehicleLog) {
    console.log(vehiclelog);
    return this.http.post(this.apiUrl + 'vehiclelog/', vehiclelog);
  }

  editUser(vehiclelog: VehicleLog) {
    console.log(vehiclelog);
    return this.http.put(this.apiUrl + 'vehiclelog/', vehiclelog);
  }
}
