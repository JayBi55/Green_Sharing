<template>
    <div class="footer-dark">
        <footer>
            <div class="container">
                <div class="row">
                    <div class="col-sm-6 col-md-3 item">
                        <h3>Contact and Informations</h3>
                        <ul>
                            <li><a href="#">Mail:xyzteam11@xxx...</a></li>
                            
                        </ul>
                    </div>
                    <div class="col-sm-6 col-md-3 item">
                        <h3>About</h3>
                        <ul>
                            <li><a href="#">Green Sharing</a></li>
                            <li><a href="#">Team 11</a></li>
                        </ul>
                    </div>
                    <div id="partenaire" class="col-md-6 item text">
                        <h3>Affiliate-Partner</h3>
                        <h4>Morgan Stanley</h4>
                        <h4>Jour de la terre</h4>
                    </div>
                    <div class="col item social">
                        <a href="#"><img src="@/assets/index11.png" alt="facebook" width="50px" height="50px"><i class="icon ion-social-facebook"></i></a>
                        <a href="#"><img src="@/assets/twitter1.png" alt="twitter" width="50px" height="50px"><i class="icon ion-social-twitter"></i></a>
                        <a href="#"><img src="@/assets/insta-logo.png" alt="insta" width="50px" height="50px"><i class="icon ion-social-instagram"></i></a>
                        <a href="#"><img src="@/assets/linkedin.png" alt="linkedin" width="50px" height="50px"><i class="icon ion-social-linkedin"></i></a>
                    </div>
                </div>
                <p class="copyright">Green Sharing © 2022</p>
            </div>
        </footer>
    </div>
</template>
<script lang="ts">
import { defineComponent } from 'vue';
import router from '@/router';

export default defineComponent({
    name: 'FooterVue',
})
</script>
<style>
    .footer-dark {
        padding:50px 0;
        color:#f0f9ff;
        background-color:#142530;

    }
    
    .footer-dark h3 {
        margin-top:0;
        margin-bottom:12px;
        font-weight:bold;
        font-size:16px;
    }
    
    .footer-dark ul {
        padding:0;
        list-style:none;
        line-height:1.6;
        font-size:14px;
        margin-bottom:0;
    }
    
    .footer-dark ul a {
        color:inherit;
        text-decoration:none;
        opacity:0.6;
    }
    
    .footer-dark ul a:hover {
        opacity:0.8;
    }
    
    @media (max-width:767px) {
        .footer-dark .item:not(.social) {
        text-align:center;
        padding-bottom:20px;
        }
    }
    
    .footer-dark .item.text {
        margin-bottom:36px;
    }
    
    @media (max-width:767px) {
        .footer-dark .item.text {
        margin-bottom:0;
        }
    }
    
    .footer-dark .item.text p {
        opacity:0.6;
        margin-bottom:0;
    }
    
    .footer-dark .item.social {
        text-align:center;
    }
    
    @media (max-width:991px) {
        .footer-dark .item.social {
        text-align:center;
        margin-top:20px;
        }
    }
    
    .footer-dark .item.social > a {
        font-size:20px;
        width:36px;
        height:36px;
        line-height:36px;
        display:inline-block;
        text-align:center;
        border-radius:50%;
        box-shadow:0 0 0 1px rgba(255,255,255,0.4);
        margin:0 8px;
        color:#fff;
        opacity:0.75;
    }
    
    .footer-dark .item.social > a:hover {
        opacity:0.9;
    }
    
    .footer-dark .copyright {
        text-align:center;
        padding-top:24px;
        opacity:0.3;
        font-size:13px;
        margin-bottom:0;
    }
    img{
        margin:-0.5em;
        padding:0;
    }
    
    https://epicbootstrap.com/snippets/footer-dark
</style>