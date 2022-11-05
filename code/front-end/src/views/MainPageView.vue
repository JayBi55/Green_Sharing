<template>
    <div class="home">
        <MainBar/>
        <TransitorieBar :userConnected="getUser"/>
        <div class="row">
            <div class="col-7">
                This is map
            </div>
            <div class="col-5">
                <div v-if="userStore.userType">
                    <h4>List of events you are already registred.</h4>
                    <table class="table table-striped table-dark thead-dark">
                        <thead style="background-color:black">
                            <th scope="col">#</th>
                            <th scope="col">Farmer Name</th>
                            <th scope="col">Date Start</th>
                            <th scope="col">Adresse</th>
                            <th scope="col">Priority</th>
                            <th scope="col">Products</th>
                        </thead>
                        <tbody>
                            <tr v-for="list in listEventRegistred" :key="list.num">
                                <td>{{list.num}}</td>
                                <td>{{list.farmerName}}</td>
                                <td>{{list.date}}</td>
                                <td>{{list.adresse}}</td>
                                <td>{{list.priority}}</td>
                                <td>{{list.products}}</td>
                            </tr>
                        </tbody>
                    </table>
                    <br/>
                    <hr/>
                    <br/>
                    <h4>List of events you have confirmations to come.</h4>
                    <table class="table table-striped table-dark thead-dark">
                        <thead style="background-color:black">
                            <th scope="col">#</th>
                            <th scope="col">Farmer Name</th>
                            <th scope="col">Date Start</th>
                            <th scope="col">Adresse</th>
                            <th scope="col">Priority</th>
                            <th scope="col">Products</th>
                        </thead>
                        <tbody>
                            <tr v-for="list in listEventConfirm" :key="list.num">
                                <td>{{list.num}}</td>
                                <td>{{list.farmerName}}</td>
                                <td>{{list.date}}</td>
                                <td>{{list.adresse}}</td>
                                <td>{{list.priority}}</td>
                                <td>{{list.products}}</td>
                            </tr>
                        </tbody>
                    </table>
                </div>

            </div>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import MainBar from '@/components/MainBar.vue';
import TransitorieBar from '@/components/TransitorieBar.vue';
import {listEventRegistred, listEventConfirm} from '@/constant/constants-duummy'
import { useUserStore } from '@/stores/user';

export default defineComponent({
    name:'MainPageView',
    components: {MainBar, TransitorieBar},
    setup() {
        const userStore = useUserStore();
        return {
            userStore,
            listEventRegistred,
            listEventConfirm
        }
    },
    computed: {
        getUser(){
            if(this.userStore){
                return this.userStore.userType
            }
            return ''
        }
    },
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