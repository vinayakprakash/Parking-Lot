import { Component, OnInit } from '@angular/core';
import { ColDef, GridApi, ColumnApi } from 'ag-grid-community';
import { VehicleLog } from '../models/vehiclelog.model';
import { NotifierService } from 'angular-notifier';
import { VehicleLogService } from '../services/vehiclelog.service';
import { Router } from '@angular/router';
import {
  NgbModal,
  NgbModalOptions,
  ModalDismissReasons
} from '@ng-bootstrap/ng-bootstrap';
import { AddVehicleLogComponent } from '../add-vehiclelog/add-vehiclelog.component';

@Component({
  selector: 'app-vehiclelog',
  templateUrl: './vehiclelog.component.html',
  styleUrls: ['./vehiclelog.component.scss']
})
export class VehiclelogComponent implements OnInit {
  constructor(
    private vehicleLogService: VehicleLogService,
    private notifierService: NotifierService,
    private router: Router,
    private modalService: NgbModal
  ) {
    this.columnDefs = this.createColumnDefs();
    this.modalOptions = {
      backdrop: 'static',
      backdropClass: 'customBackdrop'
    };
  }
  private columnDefs: ColDef[];
  private api: GridApi;
  private columnApi: ColumnApi;
  private vehicleLog: VehicleLog[];
  private logToBeEditedFromParent: any;
  private readonly notifier: NotifierService;
  modalOptions: NgbModalOptions;
  closeResult: string;
  //Get edited row
  newData = [];

  ngOnInit() {
    this.vehicleLogService.get().subscribe(
      data => {
        this.vehicleLog = data;
      },
      error => {
        console.log(error);
      }
    );
  }
  private createColumnDefs() {
    return [
      {
        headerName: 'Parking Lot Name',
        field: 'parkingLotName',
        filter: true,
        enableSorting: true,
        editable: true,
        sortable: true
      },
      {
        headerName: 'Vehicle Type',
        field: 'vehicleType',
        filter: true,
        editable: true,
        sortable: true
      },
      {
        headerName: 'VehicleRegistrationNumber',
        field: 'vehicleRegistrationNumber',
        filter: true,
        sortable: true,
        editable: true
      },
      {
        headerName: 'Weight',
        field: 'weight',
        filter: true,
        editable: true,
        sortable: true
      },
      {
        headerName: 'In Time',
        field: 'inTime',
        filter: true,
        editable: true,
        sortable: true
      },
      {
        headerName: 'Out Time',
        field: 'outTime',
        filter: true,
        editable: true,
        sortable: true
      },
      {
        headerName: 'Amount Received',
        field: 'amountReceived',
        filter: true,
        editable: false,
        sortable: true
      }
    ];
  }
  onGridReady(params): void {
    this.api = params.api;
    this.columnApi = params.columnApi;
    this.api.sizeColumnsToFit();
  }
  onSelectionChanged() {
    const selectedRows = this.api.getSelectedRows();
    this.logToBeEditedFromParent = selectedRows;
    console.log(this.logToBeEditedFromParent);

    let selectedRowsString = '';
    selectedRows.forEach(function(selectedRow, index) {
      if (index > 5) {
        return;
      }
      if (index !== 0) {
        selectedRowsString += ', ';
      }
      selectedRowsString += selectedRow.id;
    });
    if (selectedRows.length >= 5) {
      selectedRowsString += ' - and ' + (selectedRows.length - 5) + ' others';
    }
  }
  onCellEditingStopped(e) {
    //console.log(e.data);

    this.api.forEachNode(node => {
      if (!node.data.id) {
        this.newData.push(node.data);
      }
    });
    console.log('On editing stopped');
    console.log(this.newData);
  }
  onrowValueChanged(row) {
    console.log('onrowValueChanged: ');
    console.log('onrowValueChanged: ' + row);
  }
  editLog() {
    if (this.api.getSelectedRows().length === 0) {
      this.notifier.notify('error', 'Please select a row for editing');
      return;
    }
    const row = this.api.getSelectedRows();

    this.vehicleLogService.editUser(row[0]).subscribe(data => {
      this.notifier.notify('success', 'User updated successfully!!');
      console.log('Edit call output');
      console.log(data);
      this.router.navigate(['vehiclelog']);
    });
  }

  open() {
    debugger;
    this.modalService
      .open(AddVehicleLogComponent, this.modalOptions)
      .result.then(
        result => {
          this.closeResult = `Closed with: ${result}`;
        },
        reason => {
          this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
        }
      );
  }
  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }
}
