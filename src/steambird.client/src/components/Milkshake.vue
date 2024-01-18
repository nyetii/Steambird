<template>
    <div class="milkshake-component">

        <div class="text">
            <h1>Milkshake.NET</h1>
            <p>Esta é uma implementação do Milkshake.NET, uma biblioteca sobre geração randomizada de memes.</p>
            <br/>
            <h2>Como funciona?</h2>
            <p>A geração de uma imagem é composta por dois tipos de imagens: <b>Templates (Fundo)</b> e <b>Sources (Imagens que vão por cima)</b>.</p>
            <p>Basicamente, quando é chamada a geração de uma imagem, a biblioteca recebe do programa em que a implementa (este site, por exemplo) 
                os dados escolhidos aleatoriamente de um banco de dados. A partir disso, é chamada a biblioteca Magick.NET para auxiliar na manipulação
                das imagens para poder compor uma imagem final. Nesse estágio, são separadas três camadas entre as <b>Sources</b> para que se encaixem nas
                regiões e propriedades definidas do <b>Template</b> escolhido. Finalmente, as camadas são mescladas e um evento é enviado com o diretório
                onde o cache do resultado final é temporariamente guardado.
            </p>
            <br/>
            <p>O código de tanto o Milkshake.NET quanto o da sua implementação (este site) pode ser acessado no GitHub.</p>
            <span id="buttons">
            <div>
                <a class="button-link" href="https://github.com/nyetii/Milkshake.NET"><button id="generate-button">MILKSHAKE.NET</button></a>
                <a class="button-link" href="https://github.com/nyetii/Steambird/blob/master/src/Steambird.Server/Controllers/MilkshakeController.cs"><button id="generate-button">IMPLEMENTAÇÃO</button></a>
            </div>
        </span>
        </div>
        


        <div id="generated-image">
            <div v-if="placeholder" class="clickable-image">
                <img src="../assets/placeholder_1.png" alt="Image" @click="fetchImage"/>
            </div>
            <div v-else-if="imageUrl" class="clickable-image">
                <img :src="imageUrl" alt="Image" />
            </div>
            <div v-else="!placeholder && !imageUrl">
                <img src="../assets/placeholder_2.png" alt="Image" @click="fetchImage"/>
            </div>

        </div>

        <span id="buttons">
            <div>
                <button @click="fetchImage" id="generate-button">GERAR</button>
                <button @click="source = false" id="generate-button">ADICIONAR FUNDO</button>
                <button @click="source = true" id="generate-button">ADICIONAR SOURCE</button>
            </div>
        </span>
        
        <div class="forms">
            <div v-if="source">
                <SourceVue></SourceVue>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import SourceVue from './Source.vue'
</script>
<script lang="ts">


export default {
    data() {
        return {
        imageUrl: undefined as string | undefined,
        placeholder: true,
        source: false,
        formData: null
        };
    },
    mounted() {
        //this.fetchImage();
    },
    methods: {
        async fetchImage() {
            this.imageUrl = undefined;
            this.placeholder = false;
            try {
                const response = await fetch('/api/milkshake');
                
                if (!response.ok) {
                throw new Error('Failed to fetch image');
                }

                // Assuming the response is an image, convert it to a data URL
                const blob = await response.blob();
                const imageUrl = URL.createObjectURL(blob);

                
                this.imageUrl = imageUrl;
            } catch (error) {
                console.error('Error fetching image:', error);
            }
        }
    },
};
</script>

<style scoped>
    .milkshake-component {
    }

    #generated-image img {
        width: 800px;
        height: 600px;
    }

    #generated-image {
        display: flex;
        justify-content: center;
        margin: 1.5em;
    }

    .clickable-image {
        
        cursor: pointer;
        
    }

    #buttons {
        display: flex;
        justify-content: center;
    }

    #buttons div {
        display: flex;
        justify-content: center;
        width: 800px;
    }

    .button-link {
        background-color: transparent; 
    }

    #generate-button:hover {
        background-color: rgb(0, 80, 0); 
        color: rgb(240, 218, 255); 
        border-color: rgb(0, 80, 0); 
        font-weight: bold;
        cursor: pointer;
    }

    #generate-button {
        background-color: green; 
        color: aliceblue; 
        border-color: green; 
        border-radius: 10px;
        font-weight: bold;
        font-family: Calibri, Helvetica, sans-serif
    }
</style>