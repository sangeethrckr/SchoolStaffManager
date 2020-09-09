
async function GetStaff(url){
    const response =  await fetch(url, {
    method: 'GET'
  });

    return response.json();
}

async function CreateStaff( postBody){
  let response =  await fetch("http://schoolstaff.dev.com/api/staff", {
  method: 'POST',
  mode:'cors',
  headers: {
    'Content-Type': 'application/json'
  },
  body: postBody
});

  return response;
}

async function DeleteStaff(staffId){
  url = "http://schoolstaff.dev.com/api/staff/"+staffId;
  const response =  await fetch(url, {
  method: 'DELETE'
});

  return response;
}
