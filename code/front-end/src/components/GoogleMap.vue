<template>
  <GoogleMap api-key="AIzaSyDOxBpHQItSgjANE4tp8f3zjDvGTIaqIqU" backgroundColor="dark" style="width: 100%;  height: 500px" :center="center" :zoom="6">
    <Marker v-for="mark in getMarkers()" :key="mark.title" :options="{position: mark.center}">
      <InfoWindow>
        <div id="contet" style="background-color:{{mark.color}};color:white">
          <div id="siteNotice"></div>
          <h1 id="firstHeading" class="firstHeading">{{mark.title}}</h1>
          <div id="bodyContent">
            <p v-for="text, index in mark.description" :key="index">
              {{text}}
            </p>
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
  
    return { center, listofCreatedEvents};
  },

  methods: {
    getMarkers() {
      const markers = [
        {
          center: {lat: 53, lng:-70},
          title: 'Let\'s save some tomatoes here!!',
          description: ['Pierre Emile created that event', 'Starting on 2022-11-12', 'Ending before 2022-11-13', 'HIGH Priority'],
          color: 'red'
        },
        {
          center: {lat: 55.60, lng:-70.50},
          title: 'Let\'s save some Apples here!!',
          description: ['Marc Dragnir  created that event', 'Starting on 2022-11-10', 'Ending before 2022-11-13', 'HIGH Priority'],
          color: 'red'
        },
        {
          center: {lat: 45.42, lng:-75.69},
          title: 'Let\'s save some pineapples here!!',
          description: ['Luffy D  created that event', 'Starting on 2022-11-15', 'Ending before 2022-11-20', 'Low Priority'],
          color: 'green'
        },
        {
          center: {lat: 43.65, lng:-79.34},
          title: 'Let\'s save some strawberrys here!!',
          description: ['Ethan duFromage created that event', 'Starting on 2022-11-12', 'Ending before 2022-11-13', 'Low Priority'],
          color: 'green'
        },
        {
          center: {lat: 45.50, lng:-73.79},
          title: 'Let\'s save some potatoes here!!',
          description: ['Kilua created that event', 'Starting on 2022-11-15', 'Ending before 2022-11-17', 'Low Priority'],
          color: 'green'
        },
        {
          center: {lat: 46.7, lng:-75.45},
          title: 'Let\'s save some peaches here!!',
          description: ['Shanks Le Roux created that event', 'Starting on 2022-11-09', 'Ending before 2022-11-11', 'Medium Priority'],
          color: 'yellow'
        },
          
      ]
      return markers
    }
  }
});
</script>