const sql = require('mssql');
const express = require('express');

const config = {
    server: '(localdb)\\ MSSQLLocalDB',
    database: 'CMPS_339_AmusementPark',
    port: 1433
};

const app = express();
const port = 3000;

app.listen(port, () => {
    console.log('Server listening on port &{port}');
});

async function connectToDatabase() {
    try {
        await sql.connect(config);
        console.log('Connected to the SQL Server database');
    } catch (error) {
        console.log('Error connecting to the database', error);
    }
}

connectToDatabase();