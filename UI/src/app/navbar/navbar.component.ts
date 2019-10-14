import { AuthService } from '../services/auth.service';
import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  constructor(private authService: AuthService) {}
  public showVehicleLog: boolean;
  public showAdministration: boolean;
  ngOnInit(): void {
    if (
      sessionStorage.getItem('profile') === 'Operator' ||
      sessionStorage.getItem('profile') === 'Admin'
    ) {
      this.showVehicleLog = true;
    }

    if (sessionStorage.getItem('profile') === 'Admin') {
      this.showAdministration = true;
    }
  }

  logout() {
    this.authService.doLogout().then(
      () => {
        sessionStorage.setItem('token', '');
      },
      error => {
        console.log('Logout error', error);
      }
    );
  }
}
