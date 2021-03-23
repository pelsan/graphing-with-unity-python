[//]: # (Image References)

[image1]: https://user-images.githubusercontent.com/10624937/42135619-d90f2f28-7d12-11e8-8823-82b970a54d7e.gif "Trained Agent"

# Project 1: Navigation

### Introduction

This project, you will train an agent to navigate (and collect bananas!) in a large, square world.  

![Trained Agent][image1]

A reward of +1 is provided for collecting a yellow banana, and a reward of -1 is provided for collecting a blue banana.  Thus, the goal of your agent is to collect as many yellow bananas as possible while avoiding blue bananas.  

The state space has 37 dimensions and contains the agent's velocity, along with ray-based perception of objects around agent's forward direction.  Given this information, the agent has to learn how to best select actions.  Four discrete actions are available, corresponding to:
- **`0`** - move forward.
- **`1`** - move backward.
- **`2`** - turn left.
- **`3`** - turn right.

The task is episodic, and in order to solve the environment, the agent must get an average score of +13 over 100 consecutive episodes.

### Getting Started

The instruccion 1 is for Windows 10 Users with NVIDIA VideoCards, another S.O. please refer [this link](https://pytorch.org/get-started/locally/) and then  go to the number 2 Instruccion.


### Instructions

1.- NVIDIA CARDS : If you have a Nvidia VidCard you can use Pytorch and train your model faster, follow this intructions for Windows:
	
Install the latest nvidia driver [here](https://www.nvidia.com/es-la/geforce/drivers/)

Install Visual Studio 2019 16x (needed for CUDA) [here](https://visualstudio.microsoft.com/es/downloads/)

Install CUDA Kit [here, and note the version to be 11.0 ](https://docs.nvidia.com/cuda/cuda-installation-guide-microsoft-windows/index.html)

2.- Install AnaConda [here](https://www.anaconda.com/products/individual)

3.- Create a kernel "drlnd" on AnaConda and install pytorch, torchvision with cuda support, gym enviroment, mlagents and unityagents: 

	on your menu on windows , select "Anaconda3" - and then "Anaconda Prompt" it will open a new command window then 
     (For another S.O. please refer  (https://docs.anaconda.com/anaconda/install/verify-install/) ):

	write: conda create --name drlnd python=3.8 [enter]

	write: conda activate drlnd [enter]

	write: conda install -c anaconda ipykernel [enter]
	
	write: python -m ipykernel install --user --name drlnd --display-name "drlnd" [enter]

	write: pip install mlagents [enter]

	write: pip install unityagents --user [enter]

	write: conda install pytorch -c pytorch [enter]

	write: pip install torchvision===0.8.2 -f https://download.pytorch.org/whl/torch_stable.html [enter]


4.- Download the github project (git clone https://github.com/pelsan/p1_navigation.git) and open Navigation.ipynb on Jupyter


5.- Download the environment from one of the links below.  You need only select the environment that matches your operating system:
    - Linux: [click here](https://s3-us-west-1.amazonaws.com/udacity-drlnd/P1/Banana/Banana_Linux.zip)
    - Mac OSX: [click here](https://s3-us-west-1.amazonaws.com/udacity-drlnd/P1/Banana/Banana.app.zip)
    - Windows (32-bit): [click here](https://s3-us-west-1.amazonaws.com/udacity-drlnd/P1/Banana/Banana_Windows_x86.zip)
    - Windows (64-bit): [click here](https://s3-us-west-1.amazonaws.com/udacity-drlnd/P1/Banana/Banana_Windows_x86_64.zip)
    
    (_For Windows users_) Check out [this link](https://support.microsoft.com/en-us/help/827218/how-to-determine-whether-a-computer-is-running-a-32-bit-version-or-64) if you need help with determining if your computer is running a 32-bit version or 64-bit version of the Windows operating system.

    (_For AWS_) If you'd like to train the agent on AWS (and have not [enabled a virtual screen](https://github.com/Unity-Technologies/ml-agents/blob/master/docs/Training-on-Amazon-Web-Service.md)), then please use [this link](https://s3-us-west-1.amazonaws.com/udacity-drlnd/P1/Banana/Banana_Linux_NoVis.zip) to obtain the environment.

6-. Place the file in the DRLND GitHub repository, in the `p1_navigation/` folder, and unzip (or decompress) the file. 


5.- Select drlnd Kernel:

	On Jupyter Menu select "Kernel" - "Change Kernel" - "drlnd"

6.- Run the Notebook `Navigation.ipynb` 
