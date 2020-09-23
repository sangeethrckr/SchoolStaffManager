export class Staff{
    StaffId:number;
    Name:string;
    Address:Address;
    Salary:number;
    PhoneNumber:number;
    Subject:string;
    AssignedClass:string;
    Post :string;
    StaffType:number;

    constructor(){
        this.StaffId = null;
        this.Name = null;
        this.Address = new Address();
        this.Salary = null;
        this.Subject = null;
        this.AssignedClass = null;
        this.Post = null;
        this.StaffType = null;
    }
}

export class Address{
    HouseName:string;
    City:string;
    State:string;
    Pin:number;

    constructor(){
        this.HouseName = null;
        this.City = null;
        this.State = null;
        this.Pin = null;
    }
}

// export class StaffForm{
//     StaffId:number;
//     Name:string;
//     HouseName:string;
//     City:string;
//     State:string;
//     Pin:number;
//     Salary:number;
//     PhoneNumber:number;
//     Subject:string;
//     AssignedClass:string;
//     Post :string;
//     StaffType:number;
    
// }