import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuard } from './services/auth.guard';
import { NgModule } from '@angular/core';
import { VehiclelogComponent } from './vehiclelog/vehiclelog.component';
import { AddVehicleLogComponent } from './add-vehiclelog/add-vehiclelog.component';

export const rootRouterConfig: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {
    path: 'dashboard',
    component: DashboardComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'vehiclelog',
    component: VehiclelogComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'addvehiclelog',
    component: AddVehicleLogComponent
  }
];
@NgModule({
  imports: [RouterModule.forRoot(rootRouterConfig)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
