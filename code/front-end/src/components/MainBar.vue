<template>
    <div class=" main-bar p-3 d-flex justify-content-between w-100">
        <img src="@/assets/logoo.jpg" alt="warning" class="logo"/>
        <h2 class="ecriture align-self-center">Green Sharing</h2>
        <div  class="logo-sign" @click="redirectSignIn">
            <img src="@/assets/login-logo.png" alt="warning" class="logo"/><br/>
            <span class="ms-4">{{whoIsThere}}</span>
        </div>
        
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import {useUserStore} from '@/stores/user'
import router from '@/router';

export default defineComponent({
    name: 'MainBar',
    setup() {
        const userStore = useUserStore();
        return {
        userStore,
        }
    },
    computed:{
        whoIsThere(){
            if(this.userStore.userId) {
                return 'Log out'
            }
            return 'Login'
        }
    },
    methods: {
        redirectSignIn() {
            if(!this.userStore.userId){
                this.$router.push({name:'login'})
            }
            else{
                this.userStore.$reset()
                this.$router.push({name:'login'})
            }
            
        }
    }

})
</script>

<style>
.main-bar {
    background-color: #a6c4e1;
    position: sticky;
    z-index: 1;
    top: 0;
    box-shadow: 5px 10px #000023;
}

.logo-sign {
    cursor: pointer;
}

.logo {
    width:90px;
    height: 90px;
    border-radius: 80px;
}

.ecriture {
    line-height: 18px;
    font-size: 60px;
    font-family: Roboto;
}
</style>