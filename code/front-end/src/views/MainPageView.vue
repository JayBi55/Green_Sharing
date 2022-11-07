<template>
    <div class="home">
        <MainBar/>
        <TransitorieBar :userConnected="getUser"/>
        <div class="row">
            <div class="col-7">
                <div class="d-flex align-items-center ms-5">
                    <GoogleMap class="m-5"/>
                </div>
                
                <div v-if="userStore.userType==='Farmer'">
                    <h2 style="color:black">{{userStore.userName}}, those are the events you create</h2>
                    <hr/>
                    <table class="table table-striped thead-dark" style="position:relative; width: max-content;">
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
                                <td style="position:relative">
                                    <button class="me-3" style="background-color:#003778; color:white; border-radius: 10px;">Confirm</button>
                                    <button  class="me-3" style="background-color:#003778; color:white; border-radius: 10px;">Complete</button>
                                    <button  class="ms-3" style="background-color:#003778; color:white; border-radius: 10px;">Review</button>
                                    
                                
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <h2  style="color:black">Here are all the events.</h2>
                <table class="table table-striped thead-dark" style="position:relative">
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
                                <button style="background-color:##142530; color:white">Participate</button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="col-5">
                <div v-if="userStore.userType === 'Benevole'">
                    <h4 style="color:black">List of events you are already registred.</h4>
                    <table class="table table-striped table-dark thead-dark" style="position:relative">
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
                    <h4 style="color:black">List of events you have confirmations to come.</h4>
                    <table class="table table-striped table-dark thead-dark" style="position:relative">
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
                <div>
                    <article class="event" style="position:relative">
                        <h1 style="color:black">Event Article</h1>
                        <article class="event1">
                            <h2>03 March 2022 - Marc Gragnir Event</h2>
                            <p><b>Comment:</b>The participants had a great<br>
                                time and the harvest was good.</p>
                        </article>
                        <article class="event2">
                            <h2>05 October 2022- Pierre Event</h2>
                            <p><b>Comment:</b>The gleaners <b>@Marie33</b>
                                 wa so nice.</p>
                        </article>
                        <article class="event3">
                            <h2>05 October 2022 - Emile Event</h2>
                            <p><b>Comment:</b>I recommend it, <br>
                                it's worth it and it's 
                                for a good cause.</p>
                        </article>
                    </article>
                </div>
                <h1 style="color:black">Gleaning statistics</h1>
                <div class="d-flex justify-content-between" >
                        <div class="half-arc" style="--percentage:25%;">
                            <span class="label">25%</span>
                        </div>
                        <p class="text">Here the percentage increase in gleaning in recent months.</p>
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
.forecast {
    margin: 0;
    padding: .3rem;
    background-color: #142530;
    font: 1rem 'Fira Sans', sans-serif;
    color: black;
}

.forecast > h1,
.event1 {
    margin: .5rem;
    padding: .3rem;
    font-size: 1.2rem;
    width: 100%;
    height: 100px;
    position:relative;
}

.event1{
    background: right/contain content-box border-box no-repeat
        url('@/assets/gleaning-image.jpg') #e0dfc8ff;
        color:#142530 ;
        
}

.event1 > h2,
.event1 > p {
    margin: .2rem;
    font-size: 1rem;
}
.event2 {
    margin: .5rem;
    padding: .3rem;
    font-size: 1.2rem;
    width: 100%;
    height: 100px;
    position:relative;
}

.event2{
    background: right/contain content-box border-box no-repeat
        url('@/assets/gleaning2.jpg') #e0dfc8ff;
        color:#142530 ;
        
}

.event2 > h2,
.event2 > p {
    margin: .2rem;
    font-size: 1rem;
}
.event3 {
    margin: .5rem;
    padding: .3rem;
    font-size: 1.2rem;
    width: 100%;
    height: 100px;
    position:relative;
}

.event3{
    background: right/contain content-box border-box no-repeat
        url('@/assets/gleaning3.jpg') #e0dfc8ff;
        color:#142530 ;
        
}

.event3 > h2,
.event3 > p {
    margin: .2rem;
    font-size: 1rem;
}


.half-arc {
    position: relative;
    width: 200px;
    height: 100px;
    border-top-left-radius: 120px;
    border-top-right-radius: 120px;
    border-bottom: 0rem;
    background: #d9d9d9;
    box-sizing: border-box;
    overflow: hidden;
    display: flex;
    align-items: center;
    justify-content: center;
    margin-right: 20px;
}

.half-arc:before {
    content: "";
    position: relative;
    display: block;
    top: 0;
    left: 0;
    width: 100%;
    height: 200%;
    border-radius: 50%;
    background-image: conic-gradient(#9c27b0, #3f51b5 calc(var(--percentage, 0) / 2), #bbb 0);
    transition: transform .5s ease-in-out;
    z-index: 1;
    transform: rotate(270deg);
}

.half-arc:after {
    content: "";
    position: relative;
    display: block;
    background: #142530;
    z-index: 2;
    width: calc(100% - 32px);
    height: calc(200% - 32px);
    border-radius: 50%;
    top: 16px;
    left: 16px;
}

.half-arc span {
    color: #673ab7;
    z-index: 3;
    text-align: center;
    position: static;
}
.text{
    color: #142530;
}
.event{
    
    display: block; 
    margin: .2rem;
    font-size: 1rem;

}
p{
    position: relative;
}
.stat{
   position:relative;
   box-sizing: border-box;

}
</style>