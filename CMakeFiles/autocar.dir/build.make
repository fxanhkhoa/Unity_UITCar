# CMAKE generated file: DO NOT EDIT!
# Generated by "Unix Makefiles" Generator, CMake Version 3.10

# Delete rule output on recipe failure.
.DELETE_ON_ERROR:


#=============================================================================
# Special targets provided by cmake.

# Disable implicit rules so canonical targets will work.
.SUFFIXES:


# Remove some rules from gmake that .SUFFIXES does not remove.
SUFFIXES =

.SUFFIXES: .hpux_make_needs_suffix_list


# Suppress display of executed commands.
$(VERBOSE).SILENT:


# A target that is always out of date.
cmake_force:

.PHONY : cmake_force

#=============================================================================
# Set environment variables for the build.

# The shell in which to execute make rules.
SHELL = /bin/sh

# The CMake executable.
CMAKE_COMMAND = /usr/bin/cmake

# The command to remove a file.
RM = /usr/bin/cmake -E remove -f

# Escaping for special characters.
EQUALS = =

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = /home/fxanhkhoa/ThefxUITCar

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = /home/fxanhkhoa/ThefxUITCar

# Include any dependencies generated for this target.
include CMakeFiles/autocar.dir/depend.make

# Include the progress variables for this target.
include CMakeFiles/autocar.dir/progress.make

# Include the compile flags for this target's objects.
include CMakeFiles/autocar.dir/flags.make

CMakeFiles/autocar.dir/src/JsonParse.cpp.o: CMakeFiles/autocar.dir/flags.make
CMakeFiles/autocar.dir/src/JsonParse.cpp.o: src/JsonParse.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/home/fxanhkhoa/ThefxUITCar/CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Building CXX object CMakeFiles/autocar.dir/src/JsonParse.cpp.o"
	/usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles/autocar.dir/src/JsonParse.cpp.o -c /home/fxanhkhoa/ThefxUITCar/src/JsonParse.cpp

CMakeFiles/autocar.dir/src/JsonParse.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/autocar.dir/src/JsonParse.cpp.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /home/fxanhkhoa/ThefxUITCar/src/JsonParse.cpp > CMakeFiles/autocar.dir/src/JsonParse.cpp.i

CMakeFiles/autocar.dir/src/JsonParse.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/autocar.dir/src/JsonParse.cpp.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /home/fxanhkhoa/ThefxUITCar/src/JsonParse.cpp -o CMakeFiles/autocar.dir/src/JsonParse.cpp.s

CMakeFiles/autocar.dir/src/JsonParse.cpp.o.requires:

.PHONY : CMakeFiles/autocar.dir/src/JsonParse.cpp.o.requires

CMakeFiles/autocar.dir/src/JsonParse.cpp.o.provides: CMakeFiles/autocar.dir/src/JsonParse.cpp.o.requires
	$(MAKE) -f CMakeFiles/autocar.dir/build.make CMakeFiles/autocar.dir/src/JsonParse.cpp.o.provides.build
.PHONY : CMakeFiles/autocar.dir/src/JsonParse.cpp.o.provides

CMakeFiles/autocar.dir/src/JsonParse.cpp.o.provides.build: CMakeFiles/autocar.dir/src/JsonParse.cpp.o


CMakeFiles/autocar.dir/src/main.cpp.o: CMakeFiles/autocar.dir/flags.make
CMakeFiles/autocar.dir/src/main.cpp.o: src/main.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/home/fxanhkhoa/ThefxUITCar/CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Building CXX object CMakeFiles/autocar.dir/src/main.cpp.o"
	/usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles/autocar.dir/src/main.cpp.o -c /home/fxanhkhoa/ThefxUITCar/src/main.cpp

CMakeFiles/autocar.dir/src/main.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/autocar.dir/src/main.cpp.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /home/fxanhkhoa/ThefxUITCar/src/main.cpp > CMakeFiles/autocar.dir/src/main.cpp.i

CMakeFiles/autocar.dir/src/main.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/autocar.dir/src/main.cpp.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /home/fxanhkhoa/ThefxUITCar/src/main.cpp -o CMakeFiles/autocar.dir/src/main.cpp.s

CMakeFiles/autocar.dir/src/main.cpp.o.requires:

.PHONY : CMakeFiles/autocar.dir/src/main.cpp.o.requires

CMakeFiles/autocar.dir/src/main.cpp.o.provides: CMakeFiles/autocar.dir/src/main.cpp.o.requires
	$(MAKE) -f CMakeFiles/autocar.dir/build.make CMakeFiles/autocar.dir/src/main.cpp.o.provides.build
.PHONY : CMakeFiles/autocar.dir/src/main.cpp.o.provides

CMakeFiles/autocar.dir/src/main.cpp.o.provides.build: CMakeFiles/autocar.dir/src/main.cpp.o


# Object files for target autocar
autocar_OBJECTS = \
"CMakeFiles/autocar.dir/src/JsonParse.cpp.o" \
"CMakeFiles/autocar.dir/src/main.cpp.o"

# External object files for target autocar
autocar_EXTERNAL_OBJECTS =

bin/autocar: CMakeFiles/autocar.dir/src/JsonParse.cpp.o
bin/autocar: CMakeFiles/autocar.dir/src/main.cpp.o
bin/autocar: CMakeFiles/autocar.dir/build.make
bin/autocar: /usr/local/lib/libopencv_stitching.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_superres.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_videostab.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_aruco.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_bgsegm.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_bioinspired.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_ccalib.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_cvv.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_dnn_objdetect.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_dpm.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_face.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_freetype.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_fuzzy.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_hfs.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_img_hash.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_line_descriptor.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_optflow.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_reg.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_rgbd.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_saliency.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_stereo.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_structured_light.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_surface_matching.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_tracking.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_xfeatures2d.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_ximgproc.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_xobjdetect.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_xphoto.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_shape.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_phase_unwrapping.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_video.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_datasets.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_plot.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_text.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_dnn.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_ml.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_objdetect.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_calib3d.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_features2d.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_flann.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_highgui.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_videoio.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_imgcodecs.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_photo.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_imgproc.so.3.4.5
bin/autocar: /usr/local/lib/libopencv_core.so.3.4.5
bin/autocar: CMakeFiles/autocar.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir=/home/fxanhkhoa/ThefxUITCar/CMakeFiles --progress-num=$(CMAKE_PROGRESS_3) "Linking CXX executable bin/autocar"
	$(CMAKE_COMMAND) -E cmake_link_script CMakeFiles/autocar.dir/link.txt --verbose=$(VERBOSE)

# Rule to build all files generated by this target.
CMakeFiles/autocar.dir/build: bin/autocar

.PHONY : CMakeFiles/autocar.dir/build

CMakeFiles/autocar.dir/requires: CMakeFiles/autocar.dir/src/JsonParse.cpp.o.requires
CMakeFiles/autocar.dir/requires: CMakeFiles/autocar.dir/src/main.cpp.o.requires

.PHONY : CMakeFiles/autocar.dir/requires

CMakeFiles/autocar.dir/clean:
	$(CMAKE_COMMAND) -P CMakeFiles/autocar.dir/cmake_clean.cmake
.PHONY : CMakeFiles/autocar.dir/clean

CMakeFiles/autocar.dir/depend:
	cd /home/fxanhkhoa/ThefxUITCar && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" /home/fxanhkhoa/ThefxUITCar /home/fxanhkhoa/ThefxUITCar /home/fxanhkhoa/ThefxUITCar /home/fxanhkhoa/ThefxUITCar /home/fxanhkhoa/ThefxUITCar/CMakeFiles/autocar.dir/DependInfo.cmake --color=$(COLOR)
.PHONY : CMakeFiles/autocar.dir/depend
