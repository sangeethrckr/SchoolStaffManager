const siteUrl = "http://schoolstaff.dev.com";

async function GetStaff(url){
    const response =  await fetch(url, {
    method: 'GET'
  });

    ErrorHandler(response);
    return response.json();
}

async function CreateStaff( postBody){
  const response =  await fetch(siteUrl +"/api/staff", {
  method: 'POST',
  mode:'cors',
  headers: {
    'Content-Type': 'application/json'
  },
  body: postBody
});

ErrorHandler(response);


}

async function DeleteStaff(staffId){
  url = siteUrl +"/api/staff/"+staffId;
  const response =  await fetch(url, {
  method: 'DELETE'
  });
  ErrorHandler(response);
  
}

async function UpdateStaff(staffId,putBody){
  url = siteUrl +"/api/staff/"+staffId;
  const response =  await fetch(url, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json'
    },
    body: putBody
  });

  ErrorHandler(response);
}

function ErrorHandler(response){
  if (response.status >= 200 && response.status <= 299) {
    //const jsonResponse = await response.json();
    console.log("Success");
  } else {
    // Handle errors
    console.log(response.statusText, response.status);
    alert(response.statusText);
    
  }
}