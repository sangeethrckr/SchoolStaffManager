function ShowStaffPage(staffType){

    var url;
    switch(parseInt(staffType)){
        case 0:
            url = "http://schoolstaff.dev.com/api/staff?staffType=teaching";
            break;
        case 1:
            url = "http://schoolstaff.dev.com/api/staff?staffType=admin";
            break;
        case 2:
            url = "http://schoolstaff.dev.com/api/staff?staffType=support";
            break;
    }
    
    var divContainer = document.getElementById("showData");
    divContainer.innerHTML = "";
    var addStaffButton = document.createElement("input");
    addStaffButton.type = "button";
    addStaffButton.value = "Add Staff";
    addStaffButton.id = "addStaffButton";
    divContainer.appendChild(addStaffButton);

    GetStaff(url)
    .then(data => 
        {
            table = CreateTableFromJSON(data);
            table.setAttribute('id','staffTable');
            
            divContainer.appendChild(table);
        });      

    document.getElementById("addStaffButton").onclick = function(){
        if(staffType == 0){
            ToggleCreateTeacherPopUp();
        }
        else{
            ToggleCreateAdminOrSupportStaffPopUp();
        }
    };

    document.getElementById("submit").onclick = function(){
        CreateAdminOrSupportStaff(staffType);
    };

    document.getElementById("submit2").onclick = function(){
        CreateTeachingStaff(staffType);
    };
}


function CreateAdminOrSupportStaff(staffType){
    var name = document.getElementById("name").value;
    var houseName = document.getElementById("houseName").value;
    var city = document.getElementById("city").value;
    var state = document.getElementById("state").value;
    var pin = parseInt(document.getElementById("pin").value);
    var phoneNumber = document.getElementById("phoneNumber").value;
    var salary = parseFloat(document.getElementById("salary").value);
    var post = document.getElementById("post").value;
    
    

    var postBody = CreatePostMethodBodyForAdminAndSupport(post,name,houseName,city,state,pin,phoneNumber,salary,staffType);

    CreateStaff(postBody)
    .then(result=>
        {
            alert(result);
            
        })
    .then(() =>{
        ToggleCreateAdminOrSupportStaffPopUp();
        ShowStaffPage(staffType);
    });
    
    
    
}

function CreateTeachingStaff(staffType){
    var postBody;

    var name = document.getElementById("name2").value;
    var houseName = document.getElementById("houseName2").value;
    var city = document.getElementById("city2").value;
    var state = document.getElementById("state2").value;
    var pin = parseInt(document.getElementById("pin2").value);
    var phoneNumber = document.getElementById("phoneNumber2").value;
    var salary = parseFloat(document.getElementById("salary2").value);
    var subject = document.getElementById("subject2").value;
    var classAssigned = document.getElementById("classAssigned2").value;
    postBody = CreatePostMethodBodyForTeaching(subject,classAssigned,name,houseName,city,state,pin,phoneNumber,salary);

    //document.write(postBody.toString());
    var body = postBody.toString();
    
    CreateStaff(body)
    .then(result=>
        {
            alert(result);
            
        })
    .then(() =>{
        ToggleCreateTeacherPopUp();
        ShowStaffPage(staffType);
    });
    
    
    
}


function CreatePostMethodBodyForAdminAndSupport(post,name,houseName,city,state,pin,phoneNumber,salary,staffType){
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

    return result;
}

function CreatePostMethodBodyForTeaching(subject,classAssigned,name,houseName,city,state,pin,phoneNumber,salary){
    var result = JSON.stringify(
        {
            Subject: subject,
            AssignedClass: classAssigned,
            
            Name: name,
            Address: {
                HouseName: houseName,
                City: city,
                State: state,
                Pin: 123231
            },
            PhoneNumber: phoneNumber,
            Salary: 25000.0,
            StaffType: 0
        }

        );

    return result;

}



function ToggleCreateAdminOrSupportStaffPopUp() {
    var popup = document.getElementById("myPopup");
    popup.classList.toggle("show");
  
  }

function ToggleCreateTeacherPopUp() {
var popup = document.getElementById("myPopup2");
popup.classList.toggle("show");
}

function ToggleConfirmDeletePopUp(staffId,staffType) {
var popup = document.getElementById("delConfirm");
popup.classList.toggle("show");
document.getElementById("confirmDel").onclick = function(){
    DeleteStaffFromTable(staffId,staffType);
    //alert(staffId);
};
}

  
function DeleteStaffFromTable(staffId,staffType){
    DeleteStaff(staffId)
    .then(data=>{
        alert("Staff Deleted");
    })
    .then(() =>{
        ToggleConfirmDeletePopUp(staffId);
        ShowStaffPage(staffType);
    });
    
}
  
