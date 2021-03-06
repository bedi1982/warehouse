#include <stdio.h>

//beware on this one, use '\o' as a finisher example//
int array_elements_count(int *x, int size){
	int i = 0;
	int count = 0;
	
	for(i=0; i<size; i++){
		if(x[i] == '\0'){
			break;
		}
		count ++;
	}
	return count;
}


void print_array(int *x, int size){
	int i = 0;
	for(i=0; i<size; i++){
		printf("%d ", x[i]);
	}
}


int * array_sorter(int *x, int size){ 
	int i;
	int j;
	int swap; 
	int n;

        for (i = 0; i < size; ++i)
                for (j = i + 1; j < size; ++j){
                        if(x[i] > x[j]){
                                swap = x[i];
                                x[i] = x[j];
                                x[j] = swap;
                        }
                }
	return x;
}

int * array_remove_dupes(int *x, int size){
	int A[1000];
	int i = 0;
	int j = 0;
	
	for(i=0; i<size; i++){
		if(!(x[i] == x[i+1])){
			A[j] = x[i];
			j++;
		}
	}
	print_array(A, j);
}

int * array_invert(int *x, int size){
	int i = 0;
	int j = 0;
	int A[size];
	
	for(i = size-1; i >= 0; i--){
			A[j] = x[i];
			j++;
	}
	print_array(A, j);
}

int main(){
        int x[1000]= {1,2,3,4,5,6};
	int size = sizeof(x)/sizeof(int);
	
	size = array_elements_count(x,size);
	
	printf("Array elements count: %d", size);
	
	printf("\nArray data: ");
	print_array(x,size);
	
	array_sorter(x, size);
	
	printf("\nArray Sorted: ");
	print_array(x,size);
		
	printf("\nArray Uniq: ");
	array_remove_dupes(x, size);

	printf("\n\narray invert: ");
	array_invert(x, size);
	printf("\n");
}
