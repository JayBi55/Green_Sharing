<template>
    <div class="p-4 m-2">
     <div v-if="userConnected === 'Benevole'">
        <h2 class="mb-3">Good morning {{userStore.userName}}</h2>
        <div class="d-flex justify-content-between">
            <button class="button-event">Check all event by expiration date</button>
            <input type="search" class="search" placeholder="Search event by tag or farmer's names..."/>
        </div>
     </div>

     <div v-else-if="userConnected === 'Farmer'" class="row">
        <h2 class="mb-3">Good morning {{userStore.userName}}</h2>
        <div class="col-8 d-flex justify-content-between">
             <button class="button-event-farmer" style="background-color: #003778;" @click="createEvent()">Create an event</button>
            <button class="button-event-farmer" style="background-color: #F9AC28;">Update an event</button>
            <button class="button-event-farmer" style="background-color: red;">Delete an event</button>
        </div>
     </div>

     <div v-else-if="userConnected === 'Food Banks'">
     </div>
     <div v-else class="nom-equipe">
        <h3>Prototype développer par Team 11 - MORGAN STANLEY</h3>
     </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { useUserStore } from '@/stores/user';

export default defineComponent({
    name: 'TransitorieBar',
    setup() {
        const userStore = useUserStore();
        return {
            userStore,
        }
    },
    props: {
        userConnected: {
            type: String,
            required: false,
            default: ''
        }
    },

    methods: {
        createEvent() {
            this.$router.push({name:'createEvent'})
        }
    }

})
</script>

<style>
.nom-equipe {
    text-align: center;
}

.button-event{
    border-radius: 10px;
    background-color: #003778;
    width: 150px;
    color: white;
}

.search {
    border-radius: 10px;
    width: 260px;
}

.button-event-farmer {
    border-radius: 10px;
    color: white;
}
</style>