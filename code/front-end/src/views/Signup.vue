<template>
    <div class="login-css w-100 h-100">
        <div class="container">
        <img src="@/assets/logo_of.jpg" alt="warning" class="logo"/>
        <div style="bottom:60px"><h1>Green Sharing</h1></div>
<form @submit.prevent="handleSubmit">
    <label>Username : </label>
    <input type="text" v-model="userId" required/>
    <label >Password : </label>
    <input type="password" v-model="password" name="psw" id="psw" required/>
    <label >Email : </label>
    <input type="email" v-model="email" required/>
    <label >Phone Number : </label>
    <input type="text" v-model="Phonenumber" required />
        <label >Last Name : </label>
    <input type="text" v-model="lastname" required />
        <label >First Name : </label>
    <input type="text" v-model="firstname" required />
        <label >SurName : </label>
    <input type="text" v-model="surname" />
        <label >Fax Number : </label>
    <input type="text" v-model="faxnumber" />
        <Label style="margin-right:16px">Account Type : </Label>
        <select v-model="Acctype" required>
            <option value="farmer">Farmer</option>
            <option value="volunteer">Volunteer</option>
            <option value="forg">Food Organizations</option>
        </select>
        <div class="createacc"><button type="submit" class="registerbtn" @click="" style="margin-right:16px">
          Create Account
        </button></div>

              <div class="oralign"  ><p>- - OR - -</p></div>
          <div></div><div class="d-flex justify-content-between"  >
                        <a href="#"><img src="@/assets/index11.png" alt="facebook" width="50px" height="50px"><i class="icon ion-social-facebook"></i></a>
                        <a href="#"><img src="@/assets/Apple.png" alt="gmail" width="58px" height="58px"><i class="icon ion-social-apple"></i></a>
                        <a href="#"><img src="@/assets/google.png" alt="google" width="50px" height="50px"><i class="icon ion-social-google"></i></a>
          </div>
</form></div></div>
</template>

<script lang="ts" >
export default{
data(){
    return{
        userId:"",
        password:"",
        email:"",
        Phonenumber:"",
        lastname:"",
        firstname:"",
        surname:"",
        faxnumber:"",
        Acctype:"",
        pass_err:""
    }
},
methods:{
handleSubmit(){
    this.pass_err=this.password.length>6?'':'Password size must be greater than 6'
    console.log('submitted')
    const data ={
        userId:this.userId,
        password:this.password,
        email:this.email,
        Phonenumber:this.Phonenumber,
        lastname:this.lastname,
        firstname:this.firstname,
        surname:this.surname,
        faxnumber:this.faxnumber,
        Acctype:this.Acctype,
        pass_err:this.pass_err,
    }
}
}
}
methods :{

}
</script>

<style>
form{
    max-width:520px;
    margin: 30px auto;
    background: white;
    text-align: left;
    padding: 40px;
    border-radius: 15px;
   bottom:4em;
}
label{
    color: #aaa;
    display: inline-block;
    margin:25px 0 15px;
    font-size: 0.8em;
    text-transform: uppercase;
    letter-spacing: 1px;
    font-weight: bold;
}
input{
    display: black;
    padding:10px 6px;
    width :100%;
    box-sizing: border-box;
    border:none;
    border-bottom: 1px solid #ddd;
    color: #555;

}
.login-css {
  background-image: url(../images/backgroundLogIn.jpg);
  background-size: cover;
}
h1 {
  text-align: center;
  line-height: 18px;
  font-size: 60px;
  /*font-family: Roboto;*/
  color: white;
  font-family: cursive, sans-serif;
  
}
.container {
  padding: 30px;
  margin-left: 30px;
}
button{
    background: #142530;
    padding: 10px 20px;
    border: 0;
    margin-top:20px;
    color:white;
    border-radius: 20px;
    border: solid;
    cursor: pointer;

}
.createacc{
    text-align: center;
    top:17px
}
.oralign{
  font-size:1.5em;
  text-align: center;
  padding: 20px 30px;
  margin-bottom:10px;
  top: 0.5em;
}
</style>

