<template>
    <p>Source works!</p>
        <form @submit.prevent="submitForm">
            <label for="name">Name:</label>
            <input type="text" v-model="source.name" required />

            <label for="description">Description:</label>
            <input type="text" v-model="source.description" required />

            <input type="file" @change="handleFileChange" accept="image/*" />

            <button type="submit">Submit</button>
        </form>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';
    import axios from 'axios';
    import { ref } from 'vue';


    interface Source {
        name: string,
        description: string,
        tags: 0
        file: File | null
    }

    const formData = ref<Source>({
        name: '',
        description: '',
        tags: 0,
        file: null
    });

    export default defineComponent({
        data() {
            return {
                name: null,
                source: formData
            };
        },
        mounted() {
            //this.fetchImage();
        },
        methods: {
            async submitForm() {
                try {
                    const form = new FormData();
                    form.append('name', this.source.name);
                    form.append('description', this.source.description);
                    if (this.source.file) {
                    form.append('file', this.source.file);
                    }

                    const response = await axios.post('/api/Milkshake/source', form);

                    console.log('API Response:', response.data);
                } catch (error) {
                    console.error('Error sending form data:', error);
                }
            },
            handleFileChange(event: Event) {
                const target = event.target as HTMLInputElement;
                const file = target.files?.[0];
                this.source.file = file || null;

                console.log(target.files?.[0].name)
            }
        },
    });
</script>