package com.uni.lista1.models;

import jakarta.persistence.*;

@Entity
public class Adres {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    @ManyToOne
    private Kraj kraj;

    private String miejscowosc;
    private String kodPocztowy;
    private String poczta;
    private String ulica;
    private String nrDomu;
    private String nrLokalu;

    // Getters and Setters
}
