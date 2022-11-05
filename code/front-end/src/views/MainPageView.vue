<template>
    <div class="home">
        <MainBar/>
        <TransitorieBar/>
        <div class="row">
            <div class="col-8">
                This is map
            </div>
            <div class="col-4">
                This is the table
            </div>
        </div>
        <FooterVue style="bottom:0"/>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import MainBar from '@/components/MainBar.vue';
import TransitorieBar from '@/components/TransitorieBar.vue';
import FooterVue from '@/components/FooterVue.vue';

export default defineComponent({
    name:'MainPageView',
    components: {MainBar, TransitorieBar, FooterVue},
    data() {
        return {

        }
    },
})
</script>

<style>
.home {
    
}
</style>