<template>
  <div class="login-css w-100 h-100">
    <div class="container">
      <img src="@/assets/Free_Sample_Logo.jpg" alt="warning" class="logo" />
      <h1>Green Sharing</h1>
      <hr />
      <div class="row ms-5">
        <label for="text" class="label-css"><b>UserID</b></label>
        <input
          type="text"
          placeholder="Enter userId"
          v-model="userId"
          name="userId"
          id="userId"
          required
        />

        <label for="psw" class="label-css"><b>Password</b></label>
        <input
          type="password"
          placeholder="Enter Password"
          v-model="password"
          name="psw"
          id="psw"
          required
        />
      </div>

      <hr />
      <div class="d-flex align-items-center w-20 ms-5">
        <button type="submit" class="registerbtn" @click="login()">
          Login
        </button>
      </div>
    </div>
  </div>
</template>
<script lang="ts">
import { defineComponent } from "vue";
import { useUserStore } from "@/stores/user";
import { userConstants } from "@/constant/UsersConstants";

export default defineComponent({
  name: "Register",
  setup() {
    const userStore = useUserStore();
    return {
      userStore,
      userConstants,
    };
  },
  data() {
    return {
      userId: "",
      password: "",
    };
  },
  methods: {
    login() {
      // found
      const user = this.userConstants.find(
        (el) => el.userId === this.userId && el.userPassword === this.password
      );

      if (user) {
        this.userStore.userId = user.userId;
        this.userStore.userName = user.name;
        this.userStore.userType = user.userType;
        this.userStore.userPassword = user.userPassword;
        this.$router.push({ name: "home" });
        // clear donnes
        this.userId = "";
        this.password = "";
      }
      this.userId = "";
      this.password = "";
    },
  },
});
</script>

<style>
* {
  box-sizing: border-box;
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

/* Add padding to containers */
.container {
  padding: 30px;
  margin-left: 30px;
}

/* Full-width input fields */
input[type="text"],
input[type="password"] {
  width: 50%;
  padding: 15px;
  margin: 5px 0 22px 0;
  display: inline-block;
  border: none;
  background: #f1f1f1;
  align-items: center;
}

input[type="text"]:focus,
input[type="password"]:focus {
  background-color: #ddd;
  outline: none;
}

/* Overwrite default styles of hr */
hr {
  border: 1px solid #f1f1f1;
  margin-bottom: 25px;
}

/* Set a style for the submit/register button */
.registerbtn {
  background-color: #142530;
  color: white;
  border: solid;
  cursor: pointer;
  width: 10%;
}

.registerbtn:hover {
  opacity: 1;
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
  color: white;
}
</style>
