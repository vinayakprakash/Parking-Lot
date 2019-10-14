import { Component, OnInit } from '@angular/core';
import { DashboardService } from '../services/dashboard.service';
import { AuthService } from '../services/auth.service';
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  public parkingLotOverview = [];
  ngOnInit(): void {
    this.getDashboardData();
  }
  constructor(
    private dashboardService: DashboardService,
    private authService: AuthService
  ) {}
  getDashboardData() {
    this.dashboardService.get().subscribe(data => {
      this.parkingLotOverview = data;
      console.log(this.parkingLotOverview);
    });
    this.authService.setUserProfile();
  }
}
