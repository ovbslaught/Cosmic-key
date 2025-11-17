extends Node

# RedundantChannels.gd - Quantum communication backup channels
# Maintains communication when primary channels are compromised

signal channel_established(channel_id: String)
signal channel_lost(channel_id: String)
signal message_received(channel_id: String, data: Dictionary)

var active_channels: Dictionary = {}
var quantum_entanglement_pairs: Array = []
var backup_frequencies: Array = []
var channel_health: Dictionary = {}

func _ready():
	initialize_quantum_channels()
	setup_backup_frequencies()
	start_channel_monitoring()

func initialize_quantum_channels():
	# Initialize quantum entangled communication pairs
	var quantum_pairs = [
		{"pair_id": "alpha_beta", "frequency": 7.83, "stability": 0.95},
		{"pair_id": "gamma_delta", "frequency": 13.5, "stability": 0.88},
		{"pair_id": "theta_epsilon", "frequency": 21.7, "stability": 0.92}
	]
	
	for pair in quantum_pairs:
		quantum_entanglement_pairs.append(pair)
		create_redundant_channel(pair)

func create_redundant_channel(pair_data: Dictionary):
	var channel = {
		"id": pair_data.pair_id,
		"frequency": pair_data.frequency,
		"stability": pair_data.stability,
		"status": "active",
		"latency": 0.001,
		"bandwidth": 1000,
		"encryption": "quantum_key_distribution",
		"last_ping": Time.get_unix_time_from_system()
	}
	
	active_channels[pair_data.pair_id] = channel
	channel_health[pair_data.pair_id] = 100.0
	
	emit_signal("channel_established", pair_data.pair_id)

func setup_backup_frequencies():
	# Setup alternative frequency bands for emergency communication
	backup_frequencies = [
		{"band": "subspace", "range": [0.1, 1.0], "reliability": 0.75},
		{"band": "hyperspace", "range": [10.0, 100.0], "reliability": 0.85},
		{"band": "quantum_tunnel", "range": [1000.0, 10000.0], "reliability": 0.90},
		{"band": "dimensional_rift", "range": [100000.0, 1000000.0], "reliability": 0.70}
	]

func start_channel_monitoring():
	var timer = Timer.new()
	timer.wait_time = 0.5
	timer.timeout.connect(_monitor_channels)
	add_child(timer)
	timer.start()

func _monitor_channels():
	var current_time = Time.get_unix_time_from_system()
	
	for channel_id in active_channels.keys():
		var channel = active_channels[channel_id]
		var time_since_ping = current_time - channel.last_ping
		
		# Update channel health based on ping and stability
		var health_factor = (1.0 - time_since_ping / 10.0) * channel.stability
		channel_health[channel_id] = max(0.0, health_factor * 100.0)
		
		# Check if channel needs recovery
		if channel_health[channel_id] < 30.0:
			attempt_channel_recovery(channel_id)

func attempt_channel_recovery(channel_id: String):
	print("Attempting recovery for channel: ", channel_id)
	
	# Try quantum re-entanglement
	var recovery_success = randf() < 0.7
	
	if recovery_success:
		active_channels[channel_id].status = "active"
		active_channels[channel_id].last_ping = Time.get_unix_time_from_system()
		channel_health[channel_id] = 80.0
		print("Channel recovery successful: ", channel_id)
	else:
		active_channels[channel_id].status = "degraded"
		activate_backup_channel(channel_id)

func activate_backup_channel(primary_channel_id: String):
	print("Activating backup channel for: ", primary_channel_id)
	
	# Select best available backup frequency
	var best_backup = null
	var best_reliability = 0.0
	
	for backup in backup_frequencies:
		if backup.reliability > best_reliability:
			best_backup = backup
			best_reliability = backup.reliability
	
	if best_backup:
		var backup_channel_id = primary_channel_id + "_backup"
		var backup_channel = {
			"id": backup_channel_id,
			"frequency": randf_range(best_backup.range[0], best_backup.range[1]),
			"stability": best_backup.reliability,
			"status": "backup_active",
			"latency": 0.01,
			"bandwidth": 500,
			"encryption": "one_time_pad",
			"last_ping": Time.get_unix_time_from_system()
		}
		
		active_channels[backup_channel_id] = backup_channel
		channel_health[backup_channel_id] = best_backup.reliability * 100.0
		
		emit_signal("channel_established", backup_channel_id)

func send_message(channel_id: String, data: Dictionary):
	if not active_channels.has(channel_id):
		print("Channel not found: ", channel_id)
		return false
	
	var channel = active_channels[channel_id]
	
	# Check channel health before sending
	if channel_health[channel_id] < 20.0:
		print("Channel too degraded for transmission: ", channel_id)
		return false
	
	# Apply quantum encryption
	var encrypted_data = quantum_encrypt(data, channel.encryption)
	
	# Simulate transmission
	var transmission_success = randf() < channel.stability
	
	if transmission_success:
		channel.last_ping = Time.get_unix_time_from_system()
		print("Message sent successfully on channel: ", channel_id)
		return true
	else:
		print("Transmission failed on channel: ", channel_id)
		attempt_channel_recovery(channel_id)
		return false

func quantum_encrypt(data: Dictionary, encryption_type: String) -> Dictionary:
	# Apply quantum encryption based on type
	match encryption_type:
		"quantum_key_distribution":
			data["quantum_signature"] = generate_quantum_signature()
			data["entanglement_state"] = generate_entanglement_state()
		"one_time_pad":
			data["otp_key"] = generate_otp_key()
		_:
			data["basic_encryption"] = true
	
	return data

func generate_quantum_signature() -> String:
	var signature = ""
	for i in range(32):
		signature += str(randi() % 16, 16)
	return signature

func generate_entanglement_state() -> String:
	var states = ["|00⟩", "|01⟩", "|10⟩", "|11⟩", "|+⟩", "|-⟩", "|+i⟩", "|-i⟩"]
	return states[randi() % states.size()]

func generate_otp_key() -> String:
	var key = ""
	for i in range(64):
		key += str(randi() % 256, 16)
	return key

func get_channel_status() -> Dictionary:
	var status = {
		"active_channels": active_channels.size(),
		"total_health": 0.0,
		"channels": []
	}
	
	for channel_id in active_channels.keys():
		var channel_info = {
			"id": channel_id,
			"status": active_channels[channel_id].status,
			"health": channel_health[channel_id],
			"frequency": active_channels[channel_id].frequency,
			"latency": active_channels[channel_id].latency
		}
		status.channels.append(channel_info)
		status.total_health += channel_health[channel_id]
	
	if active_channels.size() > 0:
		status.total_health /= active_channels.size()
	
	return status

func emergency_broadcast(message: String):
	print("EMERGENCY BROADCAST: ", message)
	
	# Send on all available channels
	for channel_id in active_channels.keys():
		if channel_health[channel_id] > 10.0:
			var broadcast_data = {
				"type": "emergency_broadcast",
				"message": message,
				"timestamp": Time.get_unix_time_from_system(),
				"priority": "critical"
			}
			send_message(channel_id, broadcast_data)