// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener('DOMContentLoaded', function () {
    // Reservation Table Search
    const reservationSearchInput = document.getElementById('reservationSearchTerm');
    const reservationTable = document.getElementById('reservationsTable');
    const reservationRows = reservationTable.querySelectorAll('tbody tr');

    reservationSearchInput.addEventListener('input', function () {
        const searchTerm = reservationSearchInput.value.toLowerCase();

        reservationRows.forEach(row => {
            const cells = row.querySelectorAll('td');
            const customerCell = cells[0];  // CustomerId and CustomerName are in the first cell
            const roomCell = cells[1];      // RoomId and RoomType are in the second cell

            // Extract CustomerId and RoomId for comparison
            const customerId = customerCell.textContent.split('|')[0].trim().toLowerCase();
            const roomId = roomCell.textContent.split('|')[0].trim().toLowerCase();

            // Perform the comparison
            if (customerId.includes(searchTerm) || roomId.includes(searchTerm)) {
                row.style.display = '';
            } else {
                row.style.display = 'none';
            }
        });
    });


    //// Customer Table Search
    //const customerSearchInput = document.getElementById('customerSearchTerm');
    //const customerTable = document.getElementById('customersTable');
    //const customerRows = customerTable.querySelectorAll('tbody tr');

    //console.log(customerSearchInput);
    //customerSearchInput.addEventListener('input', function () {
    //    const searchTerm = customerSearchInput.value.toLowerCase();

    //    customerRows.forEach(row => {
    //        const cells = row.querySelectorAll('td');
    //        const customerIdCell = cells[0];  // CustomerId is in the first column
    //        const nameCell = cells[1];        // Name is in the second column

    //        // Extract CustomerId and Name for comparison
    //        const customerId = customerIdCell.textContent.trim().toLowerCase();
    //        const name = nameCell.textContent.trim().toLowerCase();

    //        // Perform the comparison
    //        if (customerId.includes(searchTerm) || name.includes(searchTerm)) {
    //            row.style.display = '';
    //        } else {
    //            row.style.display = 'none';
    //        }
    //    });
    //});

    //const searchInput = document.getElementById('roomSearchTerm');
    //const table = document.getElementById('roomsTable');
    //const rows = table.querySelectorAll('tbody tr');

    //searchInput.addEventListener('input', function () {
    //    const searchTerm = searchInput.value.toLowerCase();

    //    rows.forEach(row => {
    //        const cells = row.querySelectorAll('td');
    //        const roomNumberCell = cells[0];  // RoomNumber is in the first column (index 0)
    //        const roomTypeCell = cells[1];    // RoomType is in the second column (index 1)

    //        const roomNumber = roomNumberCell.textContent.trim().toLowerCase();
    //        const roomType = roomTypeCell.textContent.trim().toLowerCase();

    //        // Perform the comparison
    //        if (roomNumber.includes(searchTerm) || roomType.includes(searchTerm)) {
    //            row.style.display = '';
    //        } else {
    //            row.style.display = 'none';
    //        }
    //    });
    //});

});
