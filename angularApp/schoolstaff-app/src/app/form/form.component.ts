import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { StaffForm} from '../staff'

import { ApiConnectorsService } from '../api-connectors.service';


@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {

  staff  = new StaffForm();
  jsonString : JSON;
  staffType : number;

  constructor(
    private location: Location,
    private route: ActivatedRoute,
    private apiConnector : ApiConnectorsService,
  ) { }

  ngOnInit(): void {
    this.getStaffType();
  }

  goBack(): void {
    this.location.back();
  }

  getStaffType(){
    this.staffType = +this.route.snapshot.paramMap.get('staffType');
    //console.log(this.staffType);
  }

  onSubmit(){
    if(this.staffType == 1){
      this.jsonString = this.JsonStringifyCreateTeacher(this.staff.Subject,this.staff.AssignedClass,this.staff.Name,this.staff.HouseName,this.staff.City,this.staff.State,+this.staff.Pin,this.staff.PhoneNumber,+this.staff.Salary);
    // console.log(JSON.stringify(this.jsonString));
    }
    else{
      this.jsonString = this.JsonStringifyCreateAdminSupport(this.staff.Post,this.staff.Name,this.staff.HouseName,this.staff.City,this.staff.State,+this.staff.Pin,this.staff.PhoneNumber,+this.staff.Salary,this.staffType-1);

    }
    this.apiConnector.createStaff(this.jsonString)
        .subscribe(staff => console.log(staff));
    this.goBack();

  }

  JsonStringifyCreateTeacher(subject,classAssigned,name,houseName,city,state,pin,phoneNumber,salary){
    var result = JSON.stringify(
        {
            Subject: subject,
            AssignedClass: classAssigned,
            
            Name: name,
            Address: {
                HouseName: houseName,
                City: city,
                State: state,
                Pin: pin
            },
            PhoneNumber: phoneNumber,
            Salary: salary,
            StaffType: 0
        }

        );

    var json = JSON.parse(result);

    return json;

  }

  JsonStringifyCreateAdminSupport(post,name,houseName,city,state,pin,phoneNumber,salary,staffType){
    var result = JSON.stringify(
        {
            Post: post,
            
            Name: name,
            Address: {
                HouseName: houseName,
                City: city,
                State: state,
                Pin: pin
            },
            PhoneNumber: phoneNumber,
            Salary: salary,
            StaffType: staffType
        }
        );

        var json = JSON.parse(result);

        return json;
  }

}
