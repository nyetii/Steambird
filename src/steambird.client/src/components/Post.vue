<template>
    <div class="post-component">
        <div v-if="loading" class="loading">
                {{ $route.params.date }}
                Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationvue">https://aka.ms/jspsintegrationvue</a> for more details.
        </div>

        <div v-if="post" class="content">
            <span>{{ getDate(post.createdAt) }}</span>
            <h1>{{ post.title }}</h1>
                
            <p>{{ post.content }}</p>
        </div>
    </div>
</template>

<script lang="ts">
    import {defineComponent} from 'vue'
    import axios from 'axios'


    type Posts = {
        id: number,
        title: string,
        description: string | null,
        slug: string,
        createdAt: string,
        updatedAt: string | null,
        author: string,
        content: string
    };

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
            
            this.fetchData(this.$props.date, this.$props.slug as string);
        },
        props: {
            date: {
                type: String,
                required: true
            },
            slug: {
                type: String,
                required: true
            }
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
        },
        methods: {
            fetchData(date : string, slug : string): void {
                
                this.post = null;
                this.loading = true;

                console.log(this.post)

                const url = `/api/Post/${date}/${slug}`;

                console.log(url)

                axios.get(url)
                .then(response => {
                    this.post = response.data

                    console.log(response.data)
                    console.log(response.statusText)

                    this.loading = false;
                })
                .catch(error => {
                    console.error('Error fetching data: ', error)
                })
/*
                fetch(`api/post/${date}/${date}`)
                    .then(r => r.json())
                    .then(json => {
                        this.post = json as Posts;
                        this.loading = false;
                        return;
                    });*/
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
    .content{
        background-color: #1f1f1f;
        margin: 5%;
        padding: 5%;
        border-radius: 4em;
    }
</style>