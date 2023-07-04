﻿const URL_TO_SEND = "/Owner/api/apartments";
function addApartament() {
   
    let addApBtn = document.getElementById("addApartamentBtn");
    addApBtn.addEventListener("click", addApartamentSpecific);

    function addApartamentSpecific(event) {
        event.preventDefault();

        let addContainer = document.getElementById('addApartamentContainer');
        addContainer.style.display = 'block';
        addApBtn.style.display = 'none';

        let saveBtn = document.getElementById("saveButton");
        saveBtn.addEventListener("click", saveApartamentInDataBase);
    }

    function saveApartamentInDataBase(event) {
        event.preventDefault();

        let signature = document.getElementById("signature").value;
        let number = document.getElementById("number").value;
        let addressId = document.getElementById("currentAddressId");
        let addressIdValue = addressId.value;

        let data = {
            signature: signature,
            number: number,
            addressId: addressIdValue
        }
        let httpHeader = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        }

        fetch(URL_TO_SEND, httpHeader)
            .then(response => {
                if (response.ок) {
                    console.log('Апартаментът е създаден успешно.');
                } else {
                    console.log('Грешка при създаване на апартамент.');
                }
            })
            .catch(error => {
                console.error('Възникна грешка:', error);
            });

        let addContainer = document.getElementById('addApartamentContainer');
        addContainer.style.display = 'none';
        addApBtn.style.display = 'block';
    }
}