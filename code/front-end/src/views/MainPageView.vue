<template>
    <div class="home">
        <MainBar/>
        <TransitorieBar :userConnected="getUser"/>
        <div class="row">
            <div class="col-7">
                <div v-if="userStore.userType==='Farmer'">
                    <h2>{{userStore.userName}}, those are the events you create</h2>
                    <hr/>
                    <table class="table table-striped thead-dark">
                        <thead style="background-color:black; color:white">
                            <th scope="col">#</th>
                            <th scope="col">Date Start</th>
                            <th scope="col">Date End</th>
                            <th scope="col">Adresse</th>
                            <th scope="col">Priority</th>
                            <th scope="col">Products</th>
                            <th scope="col">Actions</th>
                        </thead>
                        <tbody>
                            <tr v-for="list in getFarmerEvents()" :key="list.num">
                                <td>{{list.num}}</td>
                                <td>{{list.startDate}}</td>
                                <td>{{list.endDate}}</td>
                                <td>{{list.adresse}}</td>
                                <td>{{list.priority}}</td>
                                <td>{{list.products}}</td>
                                <td>
                                    <button class="me-3" style="background-color:#003778; color:white; border-radius: 10px;">Confirm</button>
                                    <button  class="me-3" style="background-color:#003778; color:white; border-radius: 10px;">Complete</button>
                                    <button  class="ms-3" style="background-color:#003778; color:white; border-radius: 10px;">Review</button>
                                    
                                
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <h2>Here are all the events.</h2>
                <table class="table table-striped thead-dark">
                    <thead style="background-color:black; color:white">
                        <th scope="col">Farmer Name</th>
                        <th scope="col">Date Start</th>
                        <th scope="col">Date End</th>
                        <th scope="col">Adresse</th>
                        <th scope="col">Priority</th>
                        <th scope="col">Products</th>
                        <th scope="col" v-if="userStore.userType==='Benevole'">Actions</th>
                    </thead>
                    <tbody>
                        <tr v-for="list in listofCreatedEvents" :key="list.farmerId">
                            <td>{{list.farmerId}}</td>
                            <td>{{list.startDate}}</td>
                            <td>{{list.endDate}}</td>
                            <td>{{list.adresse}}</td>
                            <td>{{list.priority}}</td>
                            <td>{{list.products}}</td>
                            <td v-if="userStore.userType==='Benevole'">
                                <button style="background-color:#003778; color:white">Participate</button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="col-5">
                <div v-if="userStore.userType === 'Benevole'">
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
                <div v-else-if="userStore.userType === 'Farmer'">
                    <FarmerTableVue/>
                </div>
            </div>
        </div>
        <FooterVue style="bottom:-100"/>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import MainBar from '@/components/MainBar.vue';
import GoogleMap from '@/components/GoogleMap.vue';
import TransitorieBar from '@/components/TransitorieBar.vue';
import FooterVue from '@/components/FooterVue.vue';
import {listEventRegistred, listEventConfirm, listofCreatedEvents, listOfEvent} from '@/constant/constants-duummy'
import { useUserStore } from '@/stores/user';
import FarmerTableVue from '@/components/FarmerTableVue.vue';

export default defineComponent({
    name:'MainPageView',
    components: {MainBar, TransitorieBar,FooterVue, GoogleMap, FarmerTableVue },
    setup() {
        const userStore = useUserStore();
        return {
            userStore,
            listEventRegistred,
            listEventConfirm,
            listofCreatedEvents,
            listOfEvent
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
    methods: {
        getFarmerEvents() {
            const events = this.listOfEvent.find(el => el.farmerId === this.userStore.userId)
            if(events) {
                return events.events
            }
            return []
        }
    }
})
</script>

<style>
.home {
    
}
</style>