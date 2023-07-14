function addApartament() {
    let addApBtn = document.getElementById("addApartamentBtn");
    let addContainer = document.getElementById('addApartamentContainer');
    addContainer.style.display = 'block';
    addApBtn.style.display = 'none';
        
    let saveBtn = document.getElementById("saveButton");
    saveBtn.addEventListener("click", saveApartamentInDataBase);

    function saveApartamentInDataBase(event) {
        event.preventDefault();

        let signature = document.getElementById("signature").value;
        let number = Number(document.getElementById("number").value);
        let addressId = document.getElementById("currentAddressId");
        let addressIdValue = Number(addressId.value);

        let data = {
            addressId: addressIdValue,
            signature: signature,
            number: number,
        }
        let httpHeader = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        }

        fetch('https://localhost:7045/api/apartament', httpHeader)
            .then(response => {
                if (response.ok) {
                    console.log('Апартаментът е създаден успешно.');
                } else {
                    console.log('Грешка при създаване на апартамент.');
                }
            });

        let addContainer = document.getElementById('addApartamentContainer');
        addContainer.style.display = 'none';
        addApBtn.style.display = 'block';  
        
    }
}