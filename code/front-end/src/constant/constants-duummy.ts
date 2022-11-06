export const listEventRegistred = [
    
    {
        num: 1,
        farmerName: 'Pierre Emile',
        date: '2022-11-11',
        adresse: '1234 rue Jean Montreal',
        priority: 'High',
        products: 'Tomatoes'
    },
    {
        num: 2,
        farmerName: 'Jean LeRoux',
        date: '2022-11-12',
        adresse: '423 rue MaryLand',
        priority: 'High',
        products: 'Apples'
    },
    {
        num: 3,
        farmerName: 'Monkey D. Luffy',
        date: '2022-11-08',
        adresse: '2345 Av de Wano',
        priority: 'Medium',
        products: 'Avocado'
    },
    {
        num: 4,
        farmerName: 'Roronora Zorro',
        date: '2022-11-21',
        adresse: 'Nowhere',
        priority: 'Low',
        products: 'Orange'
    },
    
]

export const listEventConfirm = [
    
    {
        num: 1,
        farmerName: 'Kilua',
        date: '2022-11-15',
        adresse: 'Chateau du chantille',
        priority: 'Medium',
        products: 'Pineapple'
    },
    {
        num: 2,
        farmerName: 'Lelouch',
        date: '2022-11-20',
        adresse: '123 rue Ontario Est',
        priority: 'Low',
        products: 'Apples'
    },
    
]

export const listOfEvent = [
    {
        farmerId: 'pierre01',
        events: [
            {
                num: '1',
                startDate: '2022-11-11',
                endDate: '2022-11-13',
                adresse: '1234 rue Jean Montreal',
                priority: 'High',
                products: 'Tomatoes',
                groupePre: ['Kid friendly', 'students']
            },
            {
                num:'2',
                startDate: '2022-11-14',
                endDate: '2022-11-20',
                adresse: '1234 rue Jean Montreal',
                priority: 'Low',
                products: 'Pineapple',
                groupePre: ['Only adults']
            },
            {
                num:'3',
                startDate: '2022-11-14',
                endDate: '2022-11-15',
                adresse: '1234 rue Jean Montreal',
                priority: 'High',
                products: 'Potatoes',
                groupePre: ['Kid friendly', 'students', 'Only adults']
            },
        ]
    },
    {
        farmerId: 'marc01',
        events: [
            {
                num:1,
                startDate: '2022-11-12',
                endDate: '2022-11-12',
                adresse: '423 rue Maryland',
                priority: 'High',
                products: 'Tomatoes',
                groupePre: ['Anybody']
            },
            {
                num:2,
                startDate: '2022-11-08',
                endDate: '2022-11-20',
                adresse: '423 rue Maryland',
                priority: 'Medium',
                products: 'Apple',
                groupePre: ['Only adults']
            },
            {
                num:3,
                startDate: '2022-11-10',
                endDate: '2022-11-10',
                adresse: '1234 rue Jean Montreal',
                priority: 'High',
                products: 'Strawberry',
                groupePre: ['Kid friendly', 'students', 'Only adults']
            },
        ]
    },
    {
        farmerId: 'luffy01',
        events: [
            {
                num:1,
                startDate: '2022-11-10',
                endDate: '2022-11-10',
                adresse: '2345 Av de Wano',
                priority: 'High',
                products: 'Avocado',
                groupePre: ['Anybody']
            },
            
        ]
    },
] 

export let listofCreatedEvents = [
    {
        startDate: '2022-11-10',
        endDate: '2022-11-10',
        adresse: '2345 Av de Wano',
        priority: 'High',
        products: 'Avocado',
        groupePre: ['Anybody']
    },
    {
        startDate: '2022-11-12',
        endDate: '2022-11-12',
        adresse: '423 rue Maryland',
        priority: 'High',
        products: 'Tomatoes',
        groupePre: ['Anybody']
    },
    {
        startDate: '2022-11-08',
        endDate: '2022-11-20',
        adresse: '423 rue Maryland',
        priority: 'Medium',
        products: 'Apple',
        groupePre: ['Only adults']
    },
    {
        startDate: '2022-11-10',
        endDate: '2022-11-10',
        adresse: '1234 rue Jean Montreal',
        priority: 'High',
        products: 'Strawberry',
        groupePre: ['Kid friendly', 'students', 'Only adults']
    },
    {
        startDate: '2022-11-11',
        endDate: '2022-11-13',
        adresse: '1234 rue Jean Montreal',
        priority: 'High',
        products: 'Tomatoes',
        groupePre: ['Kid friendly', 'students']
    },
    {
        startDate: '2022-11-14',
        endDate: '2022-11-20',
        adresse: '1234 rue Jean Montreal',
        priority: 'Low',
        products: 'Pineapple',
        groupePre: ['Only adults']
    },
    {
        startDate: '2022-11-14',
        endDate: '2022-11-15',
        adresse: '1234 rue Jean Montreal',
        priority: 'High',
        products: 'Potatoes',
        groupePre: ['Kid friendly', 'students', 'Only adults']
    },
]