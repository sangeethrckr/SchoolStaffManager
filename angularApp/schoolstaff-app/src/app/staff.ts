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
        this.StaffId = 1;
        this.Name = "";
        this.Address = new Address();
        this.Salary = 12;
        this.Subject = "";
        this.AssignedClass = "";
        this.Post = "";
        this.StaffType =1;
    }
}

export class Address{
    HouseName:string;
    City:string;
    State:string;
    Pin:number;

    constructor(){
        this.HouseName = "";
        this.City = "";
        this.State = "";
        this.Pin = 1;
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