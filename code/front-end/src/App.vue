<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
  <div class="content-container m-0 p-0 w-100 h-100">
    <RouterView />
  </div>
</template>

<style>
.content-container {
  display: flex;
  min-height: 100vh;
  flex-direction: column;
  background-color: #F5F6FA;
}
</style>
