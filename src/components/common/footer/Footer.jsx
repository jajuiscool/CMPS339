import React from 'react';

import './Footer.css';

function Footer () {

    return (
        <section className="footer">
            <hr className="footer-seperator"/>
            <section className="footer-social-media">
                Where Dreams Come True!
            </section>
            <section className="footer-info">
                <section className="footer-info-left">
                <section className="footer-info__name">
                    Jolly Land
                </section>
                   
                    
                </section>
                <section className="footer-info-center">
                <section className="footer-info__email">
                    park.info@gmail.com
                </section>
                
                </section>
                <section className="footer-info-right">
                <section className="footer-info__number">
                    985-300-0000
                </section>
                
                </section>
            </section>
            <hr className="footer-seperator"/>  
        </section>
    )
}

export default Footer;