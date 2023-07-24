import React, { useState, useEffect } from 'react';
import { Header, Footer } from './components/common'

import './App.css';

function App() {

  const[backendData,setBackendData] = useState([{}])

  useEffect(() =>{
      fetch("https://localhost:7085/api/amusement-parks").then(
          response => response.json()
      ).then(
          data => {
              setBackendData(data)
          }
      ) 
  },[])

  return (
    <div className="App">
        <Header />
        <br />
        <br />
        {backendData.map(park =>(<li key={park.id}>{park.name}</li>))}
        <br />
        <br />
        <Footer />
    </div>
  );
}

export default App;
