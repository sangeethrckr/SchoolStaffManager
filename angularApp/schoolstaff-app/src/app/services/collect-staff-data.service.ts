import { Injectable } from '@angular/core';
import { Staff } from '../models/staff';

@Injectable({
  providedIn: 'root'
})
export class CollectStaffDataService {

  constructor() { }

  staff = new Staff();

  collectData(staff : Staff){
    this.staff = staff;
  }

  getData(){
    return this.staff;
  }
}
