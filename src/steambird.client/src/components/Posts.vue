<template>
    <div class="post-component">
        <div v-if="loading" class="loading">
                Carregando...
        </div>

        <div v-if="post" class="content">
            <div v-for="p in post" :key="p.id" class="post">
                <span>{{ getDate(p.createdAt) }}</span>
            <h1><a :href="`${getShortDate(p.createdAt)}/${p.slug}`">{{ p.title }}</a></h1>
                
                <div v-html="p.content"></div>
            </div>        
        </div>
    </div>
</template>

<script lang="ts">
    import {defineComponent} from 'vue'

    type Posts = {
        id: number,
        title: string,
        description: string | null,
        slug: string,
        createdAt: string,
        updatedAt: string | null,
        author: string,
        content: string
    }[];

    interface Data {
        loading: boolean,
        post: null | Posts
    }

    export default defineComponent({
        data(): Data {
            return {
                loading: false,
                post: null
            };
        },
        created() {
            // fetch the data when the view is created and the data is
            // already being observed
            this.fetchData();
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
        },
        methods: {
            fetchData(): void {
                this.post = null;
                this.loading = true;

                fetch('/api/post')
                    .then(r => r.json())
                    .then(json => {
                        this.post = json as Posts;
                        this.loading = false;
                        return;
                    });
            },
            getShortDate(created : string) {                
                let date = new Date(created);
                
                function padTo2Digits(num: number) {
                    return num.toString().padStart(2, '0');
                }

                return (
                [
                date.getFullYear(),
                padTo2Digits(date.getMonth() + 1),
                ].join('-'))
            },
            getDate(created : string) {                
                let date = new Date(created);
                
                function padTo2Digits(num: number) {
                    return num.toString().padStart(2, '0');
                }

                return (
                [
                padTo2Digits(date.getDate()),
                padTo2Digits(date.getMonth() + 1),
                date.getFullYear()
                ].join('/') + ' ' +
                [padTo2Digits(date.getHours()), padTo2Digits(date.getMinutes())].join(':'))
            }
        },
    });
</script>

<style scoped>
    .post{
        background-color: #1f1f1f;
        margin: 5%;
        padding: 5%;
        border-radius: 4em;
    }

    .post h1 {
    }
</style>