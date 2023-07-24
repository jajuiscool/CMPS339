import React from 'react';
import { Link } from 'react-router-dom'
import './Navbar.css';

function Navbar () {

    return (
        <section className='navbar'>
            <Link to='/'>Home</Link>
            <Link to='/parks'>Parks</Link>
            <a href="/contact" className="navbar-item">Where Dreams Come True!</a>
        </section>
    )
}

export default Navbar;