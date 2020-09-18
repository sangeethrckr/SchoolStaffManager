import { Component, OnInit,Input, OnChanges } from '@angular/core';
import { ApiConnectorsService } from '../api-connectors.service';
import { CollectStaffDataService } from '../collect-staff-data.service';

import {  Staff } from '../staff';

@Component({
  selector: 'app-table-view',
  templateUrl: './table-view.component.html',
  styleUrls: ['./table-view.component.css']
})
export class TableViewComponent implements OnChanges {

  @Input() staffType : number ;

  json :JSON;

  lstStaff : Staff[];

  headers = [];

  constructor(
    private apiConnector : ApiConnectorsService,
    private collectStaffData : CollectStaffDataService,
  ) { }

  ngOnChanges():void{
    this.setHeaders();
    this.getStaff();
  }

  ngOnInit():void{
    this.staffType = 1;
    this.setHeaders();
    this.getStaff();
    
  }

  

  

  getStaff(){

    switch(this.staffType){
      case 1:
        this.apiConnector.getStaff(1)
        .subscribe((data )=>{
          this.lstStaff = data;
          
        });
        break;
        
      case 2:
        this.apiConnector.getStaff(2)
        .subscribe((data )=>{
          this.lstStaff = data;
          
        });
        break;
      case 3:
        this.apiConnector.getStaff(3)
        .subscribe((data )=>{
          this.lstStaff = data;
          
        });
        break;
    }

  }

  setHeaders(){
    switch(this.staffType){
      case 1:
        this.headers = ['Name','Address','Phonenumber','Salary','Subject','Class'];
        break;
        
      case 2:
        this.headers = ['Name','Address','Phonenumber','Salary','Post'];
        break;
      case 3:
        this.headers = ['Name','Address','Phonenumber','Salary','Post'];
        break;
    }
  }

  // getId(id){
  //   this.collectStaffData.collectData(id);
  //   //console.log(id);
  // }

  collectData(staff : Staff){
    this.collectStaffData.collectData(staff);
  }

  delete(){
    event.stopPropagation();
  }

    
    

}
