<template>
    <div class=" main-bar p-3 d-flex justify-content-between w-100">
        <img src="@/assets/logoo.jpg" alt="warning" class="logo"/>
        <h2 class="ecriture align-self-center">Green Sharing</h2>
        <div>
            <img src="@/assets/login-logo.png" alt="warning" class="logo"/>
        </div>
        
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
    name: 'MainBar'

})
</script>

<style>
.main-bar {
    background-color: #2BD6F4;
    position: sticky;
    z-index: 1;
    top: 0;
    box-shadow: 5px 10px #000023;
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