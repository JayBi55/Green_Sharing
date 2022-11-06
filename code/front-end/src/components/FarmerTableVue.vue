<template>
    <h4>Upcoming Events.</h4>
        <table class="table table-striped table-dark thead-dark">
            <thead style="background-color:black">
                        <th scope="col">Date start</th>
                        <th scope="col">Date end</th>
                        <th scope="col">Priority</th>
                        <th scope="col">Products</th>
                    </thead>
                    <tbody>
                        <tr v-for="list in getFarmersEvents()" :key="list.adresse">
                                <td>{{list.startDate}}</td>
                                <td>{{list.endDate}}</td>
                                <td>{{list.priority}}</td>
                            <td>{{list.products}}</td>
                            </tr>
                        </tbody>
                    </table>
                    <br/>
                    <hr/>
                    
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import {listOfEvent} from '@/constant/constants-duummy'
import { useUserStore } from '@/stores/user';

export default defineComponent({
    name: 'FarmerTableVue',
    setup(){
        const userStore = useUserStore()
        return {
            userStore,
            listOfEvent
        }
    },
    methods: {
        getFarmersEvents(){
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
</style>