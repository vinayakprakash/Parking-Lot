import { Component, OnInit, Input } from '@angular/core';
import {
  FormControl,
  FormGroup,
  Validators,
  FormBuilder
} from '@angular/forms';
import { NotifierService } from 'angular-notifier';
import { Router, ActivatedRoute } from '@angular/router';
import { first } from 'rxjs/operators';
import { VehicleLogService } from '../services/vehiclelog.service';

@Component({
  selector: 'app-addvehiclelog',
  templateUrl: './add-vehiclelog.component.html',
  styleUrls: ['./add-vehiclelog.component.css']
})
export class AddVehicleLogComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private notifier: NotifierService,
    private vehicleLogService: VehicleLogService,
    private router: Router,
    private route: ActivatedRoute
  ) {}
  submitted = false;

  userForm: FormGroup;
  ngOnInit(): void {
    this.userForm = this.formBuilder.group({
      parkingLotName: ['', Validators.required],
      vehicleType: ['', Validators.required],
      vehicleRegistrationNumber: ['', Validators.required],
      weight: ['', Validators.required],
      inTime: ['', Validators.required],
      outTime: [''],
      amountReceived: ['']
    });
  }
  onSubmit() {
    this.submitted = true;
    if (this.userForm.invalid) {
      return;
    }
    console.log('User Object: ' + this.userForm.value);

    this.vehicleLogService.add(this.userForm.value).subscribe(data => {
      this.notifier.notify('success', 'Vehicle logged successfully!!');
      this.router.navigate(['/vehiclelog']);
    });
  }
}
