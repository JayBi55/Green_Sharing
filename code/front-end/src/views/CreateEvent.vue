<template>
    <MainBar/>
    <div v-if="IsEventCreated" class="m-5 p-5">
        <h2 class="m-5">Yayyyyy -- Your event was created....</h2>
        <button style="background-color:#22ab11; color:white" class="ms-5 button-ok" @click="redirect()">     Ok     </button>
    </div>
    <div v-else>
        <h2 class="my-4 ms-5">You are creating a new event!!</h2>
        <div class="m-5 p-5">
            <div class="d-flex mb-4">
                <label>Your userId:</label>
                <input type="text" v-model="name" placeholder="Provide your name"/>
            </div>
            <div class="d-flex mb-4">
                <label>Location:</label>
                <input type="text" v-model="location" placeholder="Enter your location"/>
            </div>
            <div class="d-flex mb-4">
                <label>Contact:</label>
                <input type="number" v-model="number" placeholder="Enter your number"/>
            </div>
            <div class="d-flex mb-4">
                <label>Capacity:</label>
                <input type="number" v-model="capacite" placeholder="Enter the estimated capacity"/>
            </div>
            <div class="d-flex justify-content-between mb-4">
                <label>Date:</label>
                <input type="text" v-model="startDatime" placeholder="Will start on"/>
                <span>To</span>
                <input type="text" v-model="endDatime" placeholder="Estimated..." />
            </div>
            <div class="d-flex mb-4">
                <label>Priority:</label>
                <input type="text" v-model="priority" placeholder="High,Medium or Low"/>
            </div>
            <div class="d-flex mb-4">
                <label>Products:</label>
                <input type="text" v-model="products" placeholder="Tomatoes, Apples, ..."/>
            </div>
            <div class="d-flex ms-4 mb-4">
                <button style="background-color:#003778; color:white" class="mx-5" @click="create()">Create</button>
                <button style="background-color:red; color:white" class="ms-5" @click="cancel()">Cancel</button>
            </div>
        </div>
    </div>
    
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import MainBar from '@/components/MainBar.vue';
import { useUserStore } from '@/stores/user';
import {listofCreatedEvents, listOfEvent} from '@/constant/constants-duummy'

export default defineComponent({
    name: 'CreateEvent',
    components: {
        MainBar
    },
    setup(){
        const userStore = useUserStore()
        return {
            userStore,
            listofCreatedEvents,
            listOfEvent
        }
    },
    data() {
        return {
          priority: '',
          endDatime:'',
          startDatime:'',
          capacite: 0,
          number:0,
          location: '',
          name:'',
          products:'',
          IsEventCreated: false,

        }
    },

    methods: {
        cancel() {
            this.$router.push({name:'home'})
        },
        create() {
           if(this.priority === 'High' || this.priority === 'Medium' || this.priority === 'Low'){
                if(this.endDatime && this.startDatime && this.capacite > 0 && this.location && this.products && this.number !== 0){
                    if(this.userStore.userId === this.name) {
                        this.IsEventCreated = true
                        const event = {
                            farmerId: this.name,
                            startDate: this.startDatime,
                            endDate: this.endDatime,
                            priority: this.priority,
                            adresse: this.location,
                            products: this.products,
                            groupePre: []
                        }
                        this.listofCreatedEvents.unshift(event)
                        console.log(this.listofCreatedEvents)

                        for(let i=0; i<=this.listOfEvent.length; i++) {
                            if(this.listOfEvent[i].farmerId === this.userStore.userId){
                                const newEv = {
                                    num: (this.listOfEvent[i].events.length + 1) + '',
                                    startDate: this.startDatime,
                                    endDate: this.endDatime,
                                    priority: this.priority,
                                    adresse: this.location,
                                    products: this.products,
                                    groupePre: []
                                }
                                this.listOfEvent[i].events.push(newEv)
                                break;
                            }
                        }
                    }
                }
           }
           this.priority = ''
           this.endDatime = ''
           this.startDatime=''
           this.capacite =0
           this.number = 0
           this.location = ''
           this.name=''
        },
        redirect() {
            this.$router.push({name:'home'})
        }
    }
})
</script>

<style>

.button-ok {
    border-radius: 20px;
    width: 50px;
}
</style>