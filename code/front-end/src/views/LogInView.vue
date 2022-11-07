<template>
    <div class="login-css w-100 h-100">
      <img src="@/assets/logo_of.jpg" alt="warning" class="logo"/>
      <h1>Green Sharing</h1>
        <div class="container">
          <hr>
          <div class="row ms-5" >
            <h2>Log In</h2>
            <label for="text" class="label-css"><b>UserID</b></label>
            <input type="text" placeholder="Enter userId"  v-model="userId" name="userId" id="userId" required>

            <label for="psw" class="label-css"><b>Password</b></label>
            <input type="password" placeholder="Enter Password" v-model="password" name="psw" id="psw" required>
          </div>
          <hr>
          <div class="social" style="position:relative">
                        <a href="#"><img src="@/assets/index11.png" alt="facebook" width="50px" height="50px"><i class="icon ion-social-facebook"></i></a>
                        <a href="#"><img src="@/assets/gmail.png" alt="gmail" width="50px" height="50px"><i class="icon ion-social-twitter"></i></a>
                        <a href="#"><img src="@/assets/insta-logo.png" alt="insta" width="50px" height="50px"><i class="icon ion-social-instagram"></i></a>
                        <a href="#"><img src="@/assets/google.png" alt="google" width="50px" height="50px"><i class="icon ion-social-linkedin"></i></a>
          </div>
          <div class="d-flex align-items-center w-20 ms-5">
            <button type="submit" class="registerbtn" @click="login()" style="margin-right:16px" >Login</button>
            <button type="submit" class="registerbtn" @click="redirectRegister()">Register</button>
          </div>
          
        </div>
    </div>

</template>
<script lang="ts">
import { defineComponent } from 'vue';
import {useUserStore} from '@/stores/user'
import { userConstants }  from '@/constant/UsersConstants'

export default defineComponent({
    name:'LogInView',
  setup() {
    const userStore = useUserStore();
    return {
      userStore,
      userConstants
    }
  },
    data() {
        return {
          userId: '',
          password: '',
        }
    },
    methods: {
      login() {
        // found
        const user = this.userConstants.find(el => 
          el.userId === this.userId && el.userPassword === this.password)
        
        if(user) {
          this.userStore.userId = user.userId;
          this.userStore.userName = user.name;
          this.userStore.userType = user.userType;
          this.userStore.userPassword = user.userPassword
          this.$router.push({name:'home'}, );
          // clear donnes
          this.userId=''
          this.password=''
        }
        this.userId=''
        this.password=''
      },
      redirectRegister() {
                this.$router.push({name:'signup'})
            
        }
      
    }
})
</script>

<style scoped>

* {box-sizing: border-box}

.login-css{
  background-image: url(../images/background.jpg);
  background-size: cover;
}
h1{
  text-align: center;
  line-height: 2em;
  font-size: 3em;
    /*font-family: Roboto;*/
  color: white;
  font-family: cursive , sans-serif;
}

/* Add padding to containers */
.container {
  padding: 3em;
  margin-left:3em;
  max-width:530px;
  margin: 20px auto;
  background: white;
  text-align: left;
  padding: 20px;
  border-radius: 40px;
  bottom:1em;
}

/* Full-width input fields */
input[type=text], input[type=password] {
  width: 90%;
  padding:25px 10px;
  margin:20px 0 15px;
  margin-left: 10px;
  margin-right: 40px;
  display: inline-block;
  border: none;
  background: #f1f1f1;
  align-items: center;
  color: #555;
}

input[type=text]:focus, input[type=password]:focus {
  background-color: #ddd;
  outline: none;
  color:black;
  border-bottom: 1px solid #ddd;
}

/* Overwrite default styles of hr */
hr {
  border: 1em solid #f1f1f1;
  margin-bottom: 12em;
}

/* Set a style for the submit/register button */
.registerbtn {
  background-color: #142530;
  color: white;
  border: solid;
  align-items: center;
  cursor: pointer;
  width: 30%;
  margin-left: 0%;
  margin:35px
  
}

.registerbtn:hover {
  opacity:1;
}

/* Add a blue text color to links */
a {
  color: dodgerblue;
}

/* Set a grey background color and center the text of the "sign in" section */
.signin {
  text-align: center;
}

.label-css {
  color: black;
}
.social{
  font-size:12em;
        width:3em;
        height:1em;
        line-height:0em;
        display:inline-block;
        text-align:center;
        border-radius:50%;
        box-shadow:0 0 0 1px rgba(255,255,255,0.4);
        color:#fff;
        opacity:0.75;
}
h2{
  color:#142530;
  text-align: center;
  font-family: cursive , sans-serif;
  font-size: 3em;
}

</style>