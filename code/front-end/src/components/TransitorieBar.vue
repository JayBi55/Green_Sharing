<template>
    <div class="p-4 m-2">
     <div v-if="getUserButtons">
        <!--BE back to implement buttons based of who is connect-->
     </div>
     <div v-else class="nom-equipe">
        <h3>Prototype développer par NOM DE L'EQUIPE</h3>
     </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
    name: 'TransitorieBar',
    
    props: {
        userConnected: {
            type: String,
            required: false,
            default: ''
        }
    },

    computed: {
        getUserButtons() {
            if(this.userConnected) { // TODO: be back to if
                return true
            }
            return false
        }
    }

})
</script>

<style>
.nom-equipe {
    text-align: center;
}
</style>