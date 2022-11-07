<template>
  <GoogleMap api-key="AIzaSyDOxBpHQItSgjANE4tp8f3zjDvGTIaqIqU" backgroundColor="dark" style="width: 100%;  height: 500px" :center="center" :zoom="6">
    <Marker v-for="mark in getMarkers()" :key="mark.title" :options="{position: mark.center}" :marker="mark.color1">
      <InfoWindow>
        <div id="contet" style="background-color:{{mark.icon}}">
          <div id="siteNotice"></div>
          <h1 id="firstHeading" class="firstHeading">{{mark.title}}</h1>
          <div id="bodyContent">
            <p v-for="text, index in mark.description" :key="index">
              {{text}}
            </p>
            <button style="background-color:##142530; color:white">Participate</button>
          </div>
        </div>
      </InfoWindow>
    </Marker>
  </GoogleMap>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { GoogleMap, Marker, InfoWindow } from "vue3-google-map";
import { listofCreatedEvents } from "@/constant/constants-duummy";

export default defineComponent({
  components: { GoogleMap, Marker, InfoWindow },
  setup() {
    const center = { lat: 45.54, lng: -73.674824 };
    const color1 ='@/asset/mm_20_green.png';
    const color2 ='@/asset/mm_20_orange.png';
    const color3 ='@/asset/mm_20_red.png';
    return { center, listofCreatedEvents,color1,color2,color3};
  },

  methods: {
    getMarkers() {
      const markers = [
        {
          center: {lat: 53, lng:-70},
          title: 'Let\'s save some tomatoes here!!',
          description: ['Pierre Emile created that event', 'Starting on 2022-11-12', 'Ending before 2022-11-13', 'HIGH Priority'],
          color: 'red',
          color3: 'color3'
        },
        {
          center: {lat: 55.60, lng:-70.50},
          title: 'Let\'s save some Apples here!!',
          description: ['Marc Dragnir  created that event', 'Starting on 2022-11-10', 'Ending before 2022-11-13', 'HIGH Priority'],
          color: 'red',
          color3: 'color3'
        },
        {
          center: {lat: 45.42, lng:-75.69},
          title: 'Let\'s save some pineapples here!!',
          description: ['Luffy D  created that event', 'Starting on 2022-11-15', 'Ending before 2022-11-20', 'Low Priority'],
          color: 'green',
          color1: 'color1'
        },
        {
          center: {lat: 45.65, lng:-79.34},
          title: 'Let\'s save some strawberrys here!!',
          description: ['Ethan duFromage created that event', 'Starting on 2022-11-12', 'Ending before 2022-11-13', 'Low Priority'],
          color: 'green',
          color1: 'color1'
        },
        {
          center: {lat: 45.50, lng:-73.79},
          title: 'Let\'s save some potatoes here!!',
          description: ['Kilua created that event', 'Starting on 2022-11-15', 'Ending before 2022-11-17', 'Low Priority'],
          color: 'green',
          color1: 'color1'
        },
        {
          center: {lat: 46.7, lng:-75.45},
          title: 'Let\'s save some peaches here!!',
          description: ['Shanks Le Roux created that event', 'Starting on 2022-11-09', 'Ending before 2022-11-11', 'Medium Priority'],
          color: 'yellow',
          color2: 'color2'

        },
          
      ]
      return markers
    }
  }
});
</script>