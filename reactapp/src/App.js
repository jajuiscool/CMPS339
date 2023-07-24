import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Home from './Pages/HomePage/HomePage'
import Parks from './Pages/AmusementParksPage/ParksPage';
import ParksById from './Pages/AmusementParksPage/ParksById';
import './App.css';


function App() {

 

  return (
    <div>
        <BrowserRouter>
        <Routes>
            <Route index element={<Home/>}/>
            <Route path="/home" element={<Home/>}/>
            <Route path="/parks" element={<Parks/>}/>
            <Route path="/parks-by-id" element={<ParksById/>}/>
       
        </Routes>
        </BrowserRouter>
    </div>
  );
}

export default App;
