import { defineStore } from 'pinia'

export const useUserStore = defineStore('user', {
    state: () => {
      return { 
        userId: '' as string,
        userType: '' as string,
        userName: '' as string,
        userPassword: '' as string,
      }
    },
})