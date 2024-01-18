<template>
    <div class="post-component">
        <div v-if="loading" class="loading">
                Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationvue">https://aka.ms/jspsintegrationvue</a> for more details.
        </div>

        <div v-if="post" class="content">
            <div v-for="p in post" :key="p.id" class="post">
                <span>{{ p.createdAt }}</span>
                <h1>{{ p.title }}</h1>
                
                <p></p>
                <p>{{ p.content }}</p>
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
            }
        },
    });
</script>

<style scoped>
    .post{
        background-color: #1f1f1f;
        margin: 5%;
        padding: 5%;
    }

    .post h1 {
        text-align: center;
    }
</style>